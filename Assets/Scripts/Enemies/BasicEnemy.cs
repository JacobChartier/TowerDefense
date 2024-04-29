using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BasicEnemy : Enemy
{
    protected override void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/basic_enemy");
        GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.744457f, 1.0f); // HEX: #40BEFF

        Health = new(3, 3);

        UpdateSize();
    }

    protected override void Update()
    {
        base.Update();

        UpdateSize();
    }
}
