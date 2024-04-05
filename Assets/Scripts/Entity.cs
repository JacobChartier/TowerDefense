using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int MaxHealthPoints { get; private set; } = 10;
    public int HealthPoints { get; private set; } = 8;

    public void AddHealthPoints(int amount)
    {
        HealthPoints += amount;
    }
}
