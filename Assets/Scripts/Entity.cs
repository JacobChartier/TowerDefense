using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Statistic<int> Health = new(10, 10);
    public Statistic<int> Defense = new(2, 2);
    public Statistic<float> Speed = new(1.0f, 5.0f);
}
