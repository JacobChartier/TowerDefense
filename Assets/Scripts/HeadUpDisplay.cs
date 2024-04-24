using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeadUpDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text levelLabel;
    [SerializeField] private Slider levelSlider;

    [Space]
    [SerializeField] private TMP_Text waveLabel;
    [SerializeField] private Slider waveSlider;

    [Space]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;

    [Space]
    [SerializeField] private TMP_Text coinsLabel;

    private void Start()
    {
        levelLabel.text = $"Level: {LevelManager.CurrentLevel}";
        levelSlider.maxValue = 5;
        levelSlider.value = LevelManager.CurrentLevel;

        waveLabel.text = $"Wave: {LevelManager.CurrentWave}";
        waveSlider.maxValue = 20;
        waveSlider.value = LevelManager.CurrentWave;

        healthText.text = $"{Player.Instance.Health.Current}/{Player.Instance.Health.MaxValue} <color=#FF4343>HP</color>";
        healthSlider.maxValue = Player.Instance.Health.MaxValue;
        healthSlider.value = Player.Instance.Health.Current;

        GameManager.Instance.pathToGoal = new();
        gameObject.GetComponent<TileManager>().GenerateMap(LevelManager.MapWidth, LevelManager.MapHeight, new Vector2(0, -0.5f));

        UpdateUIs();
    }

    public void UpdateUIs()
    {
        //GameObject.Find("Level").GetComponent<UIScaler>().UpdateUI();
        //GameObject.Find("Health").GetComponent<UIScaler>().UpdateUI();
    }
}
