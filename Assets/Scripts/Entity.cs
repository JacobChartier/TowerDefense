using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public Statistic<int> Health;
    public Statistic<int> Defense = new(2, 2);
    public Statistic<float> Speed = new(1.0f, 5.0f);

    public static HashSet<Entity> Entities { get; private set; } = new();

    protected static List<Entity> GetEntitiesInZone(Transform start, float distance)
    {
        var output = new List<Entity>();

        foreach (Entity entity in Entities)
            if (entity != null && Vector3.Distance(start.position, entity.transform.position) <= distance)
                output.Add(entity);

        return output;
    }

    protected static void Register(Entity entity)
    { Entities.Add(entity); }

    protected static void Unregister(Entity entity)
    { Entities.Remove(entity); }
}
