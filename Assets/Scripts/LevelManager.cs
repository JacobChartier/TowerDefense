using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public static int CurrentLevel { get; private set; } = 0;
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

                CurrentLevel = 0;

                break;

            case 1:
                CurrentLevel = 1;

                MapWidth = 17;
                MapHeight = 8;

                break;

            case 2:
                CurrentLevel = 2;

                MapWidth = 17;
                MapHeight = 8;

                break;

            case 3:
                CurrentLevel = 3;

                MapWidth = 16;
                MapHeight = 8;

                break;

            case 4:
                CurrentLevel = 4;

                MapWidth = 16;
                MapHeight = 8;

                break;

            case 5:
                CurrentLevel = 5;

                MapWidth = 15;
                MapHeight = 7;

                break;
        }

        Player.posX = UnityEngine.Random.Range(0, MapWidth);
        Player.posY = UnityEngine.Random.Range(0, MapHeight);
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
