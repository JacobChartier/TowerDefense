using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    internal Tile[,] tiles;

    [SerializeField] private int Width = 17;
    [SerializeField] private int Height = 7;

    private void Awake()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tile");
    }

    public void GenerateMap(int width, int height, Vector2 offset)
    {
        float posX, posY;
        bool isGray;

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

                if ((x + y) % 2 == 0)
                    isGray = false;
                else 
                    isGray = true;

                tile.GetComponent<Tile>().isGray = isGray;
            }
        }
    }
}
