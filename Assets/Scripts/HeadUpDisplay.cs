using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeadUpDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text levelLabel;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        levelLabel.text = $"Level: {LevelManager.CurrentLevel}";

        healthText.text = $"{Player.Instance.Health.Current}/{Player.Instance.Health.MaxValue} <color=#FF4343>HP</color>";
        healthSlider.maxValue = Player.Instance.Health.MaxValue;
        healthSlider.value = Player.Instance.Health.Current;

        gameObject.GetComponent<MapGenerator>().GenerateMap(LevelManager.MapWidth, LevelManager.MapHeight, new Vector2(0, -0.5f));
    }
}
