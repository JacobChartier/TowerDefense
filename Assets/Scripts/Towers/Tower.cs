using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public abstract class Tower : Entity
{
    public static List<System.Type> towers = new() { typeof(BasicTower), typeof(LaserTower), typeof(RangeTower) };

    public Sprite Icon { get; protected set; }
    public Enemy Target { get; protected set; } = null;

    public Statistic<float> Strength = new(1.0f, 10.0f);
    public Statistic<float> AttackSpeed = new(1.0f, 10.0f);

    protected bool CanAttack = true;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        Target = SearchTarget();

        Attack();
    }

    protected virtual void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/default_tower");
    }

    public virtual void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected Enemy SearchTarget()
    {
        var target = default(Enemy);

        foreach (var enemy in Enemy.Enemies)
            if (Vector3.Distance(transform.position, enemy.transform.position) < 2)
            {
                target = enemy;
                break;
            }
            else
            {
                target = null;
            }

        return target;
    }

    public static GameObject Create<T>(Transform parent = default) where T : Tower
    {
        return Create(typeof(T), parent);
    }

    public static GameObject Create(System.Type type, Transform parent = default)
    {
        var towerObject = Instantiate(Resources.Load<GameObject>("Prefabs/base_tower"), parent);
        towerObject.name = $"{type.Name}";

        var towerComponent = towerObject.AddComponent(type);

        Entity.Register((Entity)towerComponent);

        return towerObject;
    }

    public static void Destroy(Tower tower)
    {
        Tower.towers.Remove(tower.GetType());
        Entity.Unregister(tower);

        Destroy(tower.gameObject);
    }

    public static System.Type GetRandom(params System.Type[] exclusions)
    {
        var type = Tower.towers.ElementAt(Random.Range(0, Tower.towers.Count));

        if (exclusions.Contains(type))
            return GetRandom(exclusions);

        return type;
    }
}