using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
    public static int CurrentLevel { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

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
                gameObject.GetComponent<MapGenerator>().GenerateMap(17, 8);
                break;

            case 2:
                CurrentLevel = 2;
                gameObject.GetComponent<MapGenerator>().GenerateMap(17, 8);
                break;

            case 3:
                CurrentLevel = 3;
                gameObject.GetComponent<MapGenerator>().GenerateMap(16, 8);
                break;

            case 4:
                CurrentLevel = 4;
                gameObject.GetComponent<MapGenerator>().GenerateMap(16, 8);
                break;

            case 5:
                CurrentLevel = 5;
                gameObject.GetComponent<MapGenerator>().GenerateMap(15, 7);
                break;
        }
    }

    private void LoadLevel()
    {

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
