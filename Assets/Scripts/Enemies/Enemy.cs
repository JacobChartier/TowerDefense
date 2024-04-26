using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected Stack<Tile> path = new();

    private void Update()
    {
        Move();
    }

    public void SetPath(List<Tile> goal)
    {
        path.Clear();

        foreach(Tile tile in goal)
        {
            path.Push(tile);
        }
    }

    private void Move()
    {
        if (path.Count > 0)
        {
            Vector3 destination = path.Peek().transform.position;
            transform.position = Vector3.MoveTowards(transform.position, destination, (2 * Time.deltaTime));

            if (Vector3.Distance(transform.position, destination) < 0.01f)
                path.Pop();
        }
        else
        {
            Destroy(Instantiate(Resources.Load<GameObject>("Prefabs/die_particles"), gameObject.transform.localPosition, Quaternion.identity), 1);
            Destroy(this.gameObject);
        }
    }


}
