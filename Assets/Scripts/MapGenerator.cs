using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    internal Tile[,] tiles;

    [SerializeField] private int Width = 16;
    [SerializeField] private int Height = 7;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tile");
        GenerateMap(Width, Height);
    }

    private void GenerateMap(int width, int height)
    {
        float posX, posY;
        bool isGray;

        tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            posX = x - ((float)(width - 1) / 2);

            for (int y = 0; y < height; y++)
            {
                posY = y - ((float)(height - 1) / 2);

                GameObject tile = Instantiate(prefab, new Vector3(posX, posY, 0), Quaternion.identity);
                tile.name = $"Tile (X {posX}, Y {posY})";
                tiles[x, y] = tile.GetComponent<Tile>(); 

                if ((x + y) % 2 == 0)
                    isGray = false;
                else 
                    isGray = true;

                tile.GetComponent<Tile>().isGray = isGray;
            }
        }
    }
}
