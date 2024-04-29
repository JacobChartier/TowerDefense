using UnityEngine;

public class SpeedEnemy : Enemy
{
    protected override void Load()
    {
        Icon = Resources.Load<Sprite>("Sprites/basic_enemy");
        GetComponentInChildren<SpriteRenderer>().color = new Color(1.0f, 0.3f, 0.0f, 1.0f);

        Health = new(7, 7);
        Speed = new(3.5f);

        UpdateSize();
    }

    protected override void Update()
    {
        base.Update();

        UpdateSize();
    }
}