using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private float Width = 16;
    [SerializeField] private float Height = 7;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/Tile");
        GenerateMap(Width, Height);
    }

    private void GenerateMap(float width, float height)
    {
        float posX, posY;

        for (int i = 0; i < width; i++)
        {
            posX = i - ((width - 1) / 2);
            for (int j = 0; j < height; j++)
            {
                posY = j - ((height - 1) / 2);

                GameObject tile = Instantiate(prefab, new Vector3(posX, posY, 0), Quaternion.identity);
                tile.gameObject.name = $"Tile (X {posX}, Y {posY})";
            }
        }
    }
}
