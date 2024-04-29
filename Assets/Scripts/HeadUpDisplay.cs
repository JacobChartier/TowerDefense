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
    private float levelVelocity = 0;

    [Space]
    [SerializeField] private TMP_Text waveLabel;
    [SerializeField] private Slider waveSlider;
    private float waveVelocity = 0;

    [Space]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;
    private float healthVelocity = 0;

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

    private void Update()
    {
        levelSlider.value = Mathf.SmoothDamp(levelSlider.value, (int)LevelManager.CurrentLevel, ref levelVelocity, 0.3f); ;
        waveSlider.value = Mathf.SmoothDamp(waveSlider.value, LevelManager.Wave.Current, ref waveVelocity, 0.3f);
        healthSlider.value = Mathf.SmoothDamp(healthSlider.value, Player.Instance.Health.Current, ref healthVelocity, 0.3f);

        UpdateUIs();
    }

    public void UpdateUIs()
    {
        levelLabel.text = $"Level: {(int)LevelManager.CurrentLevel}";
        levelSlider.maxValue = 5;

        waveLabel.text = $"Wave: {LevelManager.Wave.Current}/{LevelManager.Wave.MaxValue}";
        waveSlider.maxValue = LevelManager.Wave.MaxValue;

        healthText.text = $"{Player.Instance.Health.Current}/{Player.Instance.Health.MaxValue} <color=#FF4343>HP</color>";
        healthSlider.maxValue = Player.Instance.Health.MaxValue;

        coinsLabel.text = $"{Player.Coins} <color=#FFD700>Coins</color>";
    }
}
