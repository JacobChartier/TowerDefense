using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeEnemy : Enemy
{
    protected override void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/basic_enemy");
        GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.6418117f, 0.2509804f, 1.0f);

        Health = new(4);
        Speed = new(3);
    }
}
