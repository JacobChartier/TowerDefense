using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    public static Player Instance;
    internal static int posX = 0, posY = 0;

    private void Awake()
    {
        Instance = this;
    }

    public static void Spawn()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/Point"), TileManager.Instance.tiles[posX, posY].transform);
    }
}
