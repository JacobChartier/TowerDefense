using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public static Player Instance;
    internal static int posX = 0, posY = 0;

    [field: SerializeField] public static int Coins { get; internal set; } = 0;

    private void Awake()
    {
        Instance = this;

        Health = new(10 + GameManager.Instance.HealthBonus, 10 + GameManager.Instance.HealthBonus);
    }

    public static void Spawn()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Point"), TileManager.Instance.tiles[posX, posY].transform);
    }

    public static void ChangeHealth(int value)
    {
        Instance.Health.Current += value; 
        HeadUpDisplay.Instance.UpdateUIs();
    }
}
