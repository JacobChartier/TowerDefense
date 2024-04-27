using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Tower : Entity
{
    public static List<System.Type> towers = new() { typeof(BasicTower), typeof(LaserTower), typeof(RangeTower) };

    public Sprite Icon { get; protected set; }

    public Statistic<float> Strength = new(1.0f, 10.0f);
    public Statistic<float> AttackSpeed = new(1.0f, 10.0f);

    private void Start()
    {
        Load();
    }

    protected virtual void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/default_tower");
    }

    public virtual float Attack()
    {
        throw new System.NotImplementedException();
    }

    public static GameObject Create<T>(Transform parent = default) where T : Tower
    {
        return Create(typeof(T), parent);
    }

    public static GameObject Create(System.Type type, Transform parent = default)
    {
        var towerObject = Instantiate(Resources.Load<GameObject>("Prefabs/tower"), parent);
        towerObject.name = $"{type.Name}";

        var towerComponent = towerObject.AddComponent(type);

        return towerObject;
    }

    public static System.Type GetRandom(params System.Type[] exclusions)
    {
        var type = Tower.towers.ElementAt(Random.Range(0, Tower.towers.Count));

        if (exclusions.Contains(type))
            return GetRandom(exclusions);

        return type;
    }
}