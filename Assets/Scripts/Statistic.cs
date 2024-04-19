using System;
using UnityEngine;

[Serializable]
public struct Statistic<T>
{
    [SerializeField] public T Current;
    [SerializeField] public T MaxValue;

    public Statistic(T value, T maxValue)
    {
        Current = value;
        MaxValue = maxValue;
    }
}
