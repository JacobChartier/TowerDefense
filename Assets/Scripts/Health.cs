using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP { get; private set; } = 10;

    public float Add(float value) { return HP += value; }
    public float Remove(float value) { return HP -= value; }
}
