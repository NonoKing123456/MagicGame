using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private GameObject readyNotice;
    [SerializeField] private GameObject gameOverNotice;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject startNotice;
    [SerializeField] private GameObject victoryNotice;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject manaBar;
    [SerializeField] private GameManager.GameState gameState = GameManager.GameState.GameOver;
    [SerializeField] private GameObject levelInfo;
    [SerializeField] private float gameStartTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InitLevelData(GameManager.Instance.CurrentLevelData);
    }
    // Update is called once per frame
    void Update()
    {
        GameManager.GameState newState = GameManager.Instance.CurrentGameState;
        HandleGameStateChange(newState);
        pauseButton.SetActive(gameState != GameManager.GameState.Paused);
        settingsUI.SetActive(gameState == GameManager.GameState.Paused);
        readyNotice.SetActive(gameState == GameManager.GameState.Ready && Time.time < gameStartTime - 0.5f);
        startNotice.SetActive(gameState == GameManager.GameState.Ready && Time.time > gameStartTime -0.5f);
        gameOverNotice.SetActive(gameState == GameManager.GameState.GameOver);
    }

    private void HandleGameStateChange(GameManager.GameState newState)
    {
        if (newState == gameState) return;
        if (gameState == GameManager.GameState.Victory)
        {
            victoryNotice.SetActive(false);
        }
        if (newState == GameManager.GameState.Ready)
        {
            gameStartTime = Time.time + GameManager.Instance.ReadyTime;
        }
        if (newState == GameManager.GameState.Victory)
        {
            Invoke("ActivateVictory", 0.5f);
        }
        gameState = newState;
    }

    public void GameOver()
    {
        gameOverNotice.SetActive(true);
    }

    public GameObject ReadyNotice => readyNotice;
    
    private void HideStartNotice()
    {
        startNotice.SetActive(false);
    }
    public void ActivateVictory()
    {
        victoryNotice.SetActive(true);
    }
    public void HandlePauseClick()
    {
        GameManager.Instance.Pause();
        AudioManager.Instance.PlayButtonClick();
    }

    internal void InitLevelData(LevelCatalog.LevelData currentLevelData)
    {
        levelInfo.GetComponent<TextMeshProUGUI>().text = "Level " + (GameManager.Instance.levelIndex + 1) + ": " + currentLevelData.levelName;
    }
}
