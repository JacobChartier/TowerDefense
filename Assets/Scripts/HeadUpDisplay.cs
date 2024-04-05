using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeadUpDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text levelLabel;

    private void Start()
    {
        levelLabel.text = $"Level #{LevelManager.CurrentLevel}";
    }
}
