using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : Entity
{
    public static HashSet<Enemy> Enemies = new();
    public static List<System.Type> Types = new() { typeof(BasicEnemy), typeof(SpeedEnemy), typeof(HealerEnemy) };

    protected Stack<Tile> path = new();
    public Sprite Icon { get; protected set; } = null;

    private void Start()
    {
        Load();

        if (Icon == null)
            Debug.LogWarning($"Unable to load the icon for enemy type <b>{typeof(Enemy)}</b>!", this );

        transform.GetComponentInChildren<SpriteRenderer>(true).sprite = Icon;
    }

    protected virtual void Update()
    {
        Move();

        if (Health.Current <= 0)
            Die();
    }

    protected void UpdateSize()
    {
        float newSize = Mathf.Lerp(0.2f, 0.8f, (float)(Health.Current / Health.MaxValue));
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    protected virtual void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/default_enemy");
    }

    protected virtual void Die()
    {
        Player.Coins += Random.Range(1, 3);

        EnemySpawner.enemies.Remove(this.gameObject);
        Enemies.Remove(this);
        Entity.Unregister(this);

        Destroy(Instantiate(Resources.Load<GameObject>("Prefabs/die_particles"), gameObject.transform.localPosition, Quaternion.identity), 1);
        Destroy(this.gameObject);
    }

    public void SetPath(List<Tile> goal)
    {
        path.Clear();

        foreach(Tile tile in goal)
        {
            path.Push(tile);
        }
    }

    protected virtual void Move()
    {
        if (path.Count > 0)
        {
            Vector3 destination = path.Peek().transform.position;
            transform.position = Vector3.MoveTowards(transform.position, destination, (Speed.Current * Time.deltaTime));

            if (Vector3.Distance(transform.position, destination) < 0.01f)
                path.Pop();
        }
        else
        {
            Player.ChangeHealth(-1);

            Die();
        }
    }

    public static GameObject Create<T>(Vector3 position = default, Quaternion rotation = default) where T : Enemy
    {
        return Create(typeof(T), position, rotation);
    }

    public static GameObject Create(System.Type type, Vector3 position = default, Quaternion rotation = default)
    {
        GameObject enemyObject = Instantiate(Resources.Load<GameObject>("Prefabs/base_enemy"), position, rotation);
        enemyObject.name = type.Name;

        var enemyComponent = enemyObject.AddComponent(type);

        Enemies.Add((Enemy)enemyComponent);

        Entity.Register((Entity)enemyComponent);

        return enemyObject;
    }

    public static System.Type GetRandom(params System.Type[] exclusions)
    {
        var type = Enemy.Types.ElementAt(Random.Range(0, Enemy.Types.Count));

        if (exclusions.Contains(type))
            return GetRandom(exclusions);

        return type;
    }
}
