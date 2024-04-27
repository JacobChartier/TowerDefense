using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeadUpDisplay : MonoBehaviour
{
    public static HeadUpDisplay Instance;

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

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUIs();

        GameManager.Instance.pathToGoal = new();
        gameObject.GetComponent<TileManager>().GenerateMap(LevelManager.MapWidth, LevelManager.MapHeight, new Vector2(0, -0.5f));
    }

    public void UpdateUIs()
    {
        levelLabel.text = $"Level: {(int)LevelManager.CurrentLevel}";
        levelSlider.maxValue = 5;
        levelSlider.value = (int)LevelManager.CurrentLevel;

        waveLabel.text = $"Wave: {LevelManager.Wave.Current}";
        waveSlider.maxValue = LevelManager.Wave.MaxValue;
        waveSlider.value = LevelManager.Wave.Current;

        healthText.text = $"{Player.Instance.Health.Current}/{Player.Instance.Health.MaxValue} <color=#FF4343>HP</color>";
        healthSlider.maxValue = Player.Instance.Health.MaxValue;
        healthSlider.value = Player.Instance.Health.Current;

        coinsLabel.text = $"{Player.Coins} <color=#FFD700>Coins</color>";
    }
}
