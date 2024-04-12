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

    public void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
