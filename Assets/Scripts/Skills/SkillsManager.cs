using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    public static SkillsManager instance;
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_Text bonuses;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EnableMenu(false);

        bonuses.text = $"<b>Current Bonuses:</b><size=-5>\r\n+ 32 <color=#FF4343>HP</color>";
    }

    public void EnableMenu(bool enable)
    {
        menu.SetActive(enable);
    }
}
