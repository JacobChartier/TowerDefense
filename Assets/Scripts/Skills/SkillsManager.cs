using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    public static SkillsManager instance;
    [SerializeField] private GameObject menu;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EnableMenu(false);
    }

    public void EnableMenu(bool enable)
    {
        menu.SetActive(enable);
    }
}
