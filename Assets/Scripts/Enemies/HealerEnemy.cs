using UnityEngine;

public class HealerEnemy : Enemy
{
    protected override void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/basic_enemy");
        GetComponentInChildren<SpriteRenderer>().color = new Color(0.0f, 1.0f, 0.15f, 1.0f);

        Health = new(5, 5);

        UpdateSize();
    }

    protected override void Update()
    {
        base.Update();

        UpdateSize();
    }
}
