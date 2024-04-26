using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    public Tile spawnTile;
    public Tile TargetTile { get; internal set; }
    public List<Tile> pathToGoal = new();

    private void Update()
    {
        if (spawnTile != TileManager.Instance.tiles[Player.posX, Player.posY])
            spawnTile = TileManager.Instance.tiles[Player.posX, Player.posY];

        if (Input.GetKeyUp(KeyCode.Space) && TargetTile != null)
        {
            foreach (var t in GameObject.Find("Level Loader").GetComponent<TileManager>().tiles)
            {
                if (t.isWall) continue;

                t.SetPath(false);
            }

            var path = GameObject.Find("Level Loader").GetComponent<TileManager>().PathFinding(spawnTile, TargetTile);
            var tile = TargetTile;

            while (tile != null)
            {
                pathToGoal.Add(tile);
                tile.isPath = true;
                tile = path[tile];
            }

            StartCoroutine(EnnemySpawner.Spawn());
        }
    }

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
