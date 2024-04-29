using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public static Levels CurrentLevel { get; private set; } = 0;
    [field: SerializeField] public static Statistic<int> Wave = new(0, 20);
    public static int MapWidth { get; private set; } = 0;
    public static int MapHeight { get; private set; } = 0;

    public static GameObject playerPrefab;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    public void SetLevel(int level)
    {
        switch (level)
        {
            case 0:
                CurrentLevel = Levels.MAIN_MENU;

                break;

            case 1:
                CurrentLevel = Levels.LEVEL_1;

                MapWidth = 17;
                MapHeight = 8;

                InitializeLevel(3);

                break;

            case 2:
                CurrentLevel = Levels.LEVEL_2;

                MapWidth = 17;
                MapHeight = 8;

                InitializeLevel(15);

                break;

            case 3:
                CurrentLevel = Levels.LEVEL_3;

                MapWidth = 16;
                MapHeight = 8;

                InitializeLevel(20);

                break;

            case 4:
                CurrentLevel = Levels.LEVEL_4;

                MapWidth = 16;
                MapHeight = 8;

                InitializeLevel(30);

                break;

            case 5:
                CurrentLevel = Levels.LEVEL_5;

                MapWidth = 15;
                MapHeight = 7;

                InitializeLevel(50);

                break;
        }

        Player.posX = UnityEngine.Random.Range(0, MapWidth);
        Player.posY = UnityEngine.Random.Range(0, MapHeight);
    }

    public static void InitializeLevel(int waves)
    {
        Wave.MaxValue = waves;
        Wave.Current = 1;
    }

    public static void EndWave()
    {
        Player.Coins += UnityEngine.Random.Range(1, 6);

        if (Wave.Current == Wave.MaxValue)
        {
            GameManager.Instance.StopAllCoroutines();
            return;
        }

        Wave.Current++;
    }
}

[Serializable]
public enum Levels
{
    MAIN_MENU = 0,

    LEVEL_1 = 1,
    LEVEL_2 = 2,
    LEVEL_3 = 3,
    LEVEL_4 = 4,
    LEVEL_5 = 5,
}
