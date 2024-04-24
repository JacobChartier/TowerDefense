using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;
    [SerializeField] private GameObject prefab;

    internal Tile[,] tiles;

    [SerializeField] private int Width;
    [SerializeField] private int Height;

    private void Awake()
    {
        Instance = this;

        prefab = Resources.Load<GameObject>("Prefabs/Tile");
    }

    public void GenerateMap(int width, int height, Vector2 offset)
    {
        float posX, posY;
        bool isGray;

        Width = width;
        Height = height;

        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            posX = x - ((float)(width - 1) / 2) + offset.x;

            for (int y = 0; y < height; y++)
            {
                posY = y - ((float)(height - 1) / 2) + offset.y;

                GameObject tile = Instantiate(prefab, new Vector3(posX, posY, 0), Quaternion.identity, GameObject.Find("Tiles").transform);
                tile.name = $"Tile (X {posX}, Y {posY})";
                tiles[x, y] = tile.GetComponent<Tile>();

                tiles[x, y].X = x;
                tiles[x, y].Y = y;

                if ((x + y) % 2 == 0)
                    isGray = false;
                else
                    isGray = true;

                tiles[x, y].isGray = isGray;
            }
        }

        Player.Spawn();
    }

    internal Dictionary<Tile, Tile> PathFinding(Tile source, Tile destination)
    {
        var dist = new Dictionary<Tile, int>(); // dist: Distance minimal de la tuile à la source.
        var prev = new Dictionary<Tile, Tile>(); // prev: Tuile précèdente qui mène au chemin le plus court.
        var Q = new List<Tile>(); // Q: List des tuiles restantes.

        foreach (var v in tiles)
        {
            dist.Add(v, 9999);
            prev.Add(v, null);
            Q.Add(v);
        }

        dist[source] = 0;

        while (Q.Count > 0)
        {
            Tile u = null;
            int minDist = int.MaxValue;

            foreach (var v in Q)
            {
                if (dist[v] < minDist)
                {
                    minDist = dist[v];
                    u = v;
                }
            }

            Q.Remove(u);

            foreach (var v in FindNeighbor(u))
            {
                if (!Q.Contains(v) || v.isWall)
                    continue;

                var alt = dist[u] + 1;

                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        return prev;
    }

    private List<Tile> FindNeighbor(Tile u)
    {
        var output = new List<Tile>();

        if (u.X - 1 >= 0)
            output.Add(tiles[(u.X - 1), u.Y]);

        if (u.X + 1 < Width)
            output.Add(tiles[(u.X + 1), u.Y]);

        if (u.Y - 1 >= 0)
            output.Add(tiles[u.X, (u.Y - 1)]);

        if (u.Y + 1 < Height)
            output.Add(tiles[u.X, (u.Y + 1)]);

        return output;
    }
}
