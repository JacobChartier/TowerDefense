using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{
    protected override void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/basic_enemy");
        GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        Health = new(8);
        Speed = new(2);
    }
}
