using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : Entity, ITowerBase
{
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

    public float Attack()
    {
        throw new System.NotImplementedException();
    }
}
