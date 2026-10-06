using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private LevelCatalog levelCatalog;
    [SerializeField] public int levelIndex;
    [SerializeField] private float readyTime = 2f;
    public float ReadyTime => readyTime;
    private LevelCatalog.LevelData currentLevelData;
    public LevelCatalog.LevelData CurrentLevelData => currentLevelData;
    public enum GameState
    {
        Ready,
        Playing,
        Paused,
        GameOver,
        Victory
    }

    private GameState currentState = GameState.Ready;
    public GameState CurrentGameState => currentState;

    // Awake方法在脚本实例被加载时被调用，仅执行一次
    private void Awake()
    {
        ManageInstance();
        if (Instance != this) return;
        ClearLevel();
        // 调用ManageInstance方法进行实例管理
        InitLevelData();
        Time.timeScale = 1f;
        GameUtils.Delay((readyTime), () => ChangeState(GameState.Playing));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (currentState == GameState.Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void ManageInstance()
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
    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    private void ChangeState(GameState newState)
    {
        
        if (newState == currentState) return;
        if (currentState == GameState.Paused)
        {
            Time.timeScale = 1f;
            AudioManager.Instance.ResumeMusic();
        }

        if (newState == GameState.Playing)
        {
            if (currentState == GameState.Paused)
            {
                // 恢复游戏
            }else if (currentState == GameState.GameOver || currentState == GameState.Victory || currentState == GameState.Ready)
            {
                InitPlayingPart();
            }
        }
        else if (newState == GameState.GameOver)
        {
            if (EnemyManager.Instance != null) EnemyManager.Instance.StopEnemySpawning();
            Time.timeScale = 0f;
        }else if (newState == GameState.Victory)
        {
            if (EnemyManager.Instance != null) EnemyManager.Instance.StopEnemySpawning();
        }else if (newState == GameState.Ready)
        {
            EnemyManager.Instance.RemoveAllEnemmySpawning();
            Time.timeScale = 1f;
            ClearLevel();
            InitLevelData();
            UIManager.Instance.InitLevelData(currentLevelData);
            GameUtils.Delay((2f), () => ChangeState(GameState.Playing));
            ManaManager.Instance.SetMana(0);
        }
        else if (newState == GameState.Paused)
        {
            Time.timeScale = 0f;
            AudioManager.Instance.PauseMusic();
        }
        currentState = newState;
    }

    private void InitLevelData()
    {
        levelIndex = GameSession.Instance.selectedLevel;
        currentLevelData = levelCatalog.levelData[levelIndex];
    }

    public void RestartLevel()
    {
        ChangeState(GameState.Ready);
    }
    public void NextLevel()
    {
        GameSession.Instance.selectedLevel++;
        if (GameSession.Instance.selectedLevel >= levelCatalog.levelData.Length)
        {
            SceneManager.LoadScene("ThanksScene");
        }
        ChangeState(GameState.Ready);
    }
    private void InitPlayingPart()
    {
        ManaManager.Instance.SetMana(currentLevelData.initMana);
        EnemyManager.Instance.InitGridsAndLevel();
    }

    private void ClearLevel()
    {
        // 清理当前关卡
        Debug.Log("Clearing level");
        GameObject[] objects = GameObject.FindObjectsByType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.transform.GetComponent<Enemy>() != null || obj.transform.GetComponent<Character>() != null || obj.transform.GetComponent<Projectile>() != null || obj.transform.GetComponent<Mana>() != null)
            {
                Destroy(obj);
            }
        }
    }

    internal void WinGame()
    {
        ChangeState(GameState.Victory);
    }

    internal void Resume()
    {
        ChangeState(GameState.Playing);
    }
    internal void Pause()
    {
        if (currentState == GameState.Ready) return;
        ChangeState(GameState.Paused);
    }
    internal void Restart()
    {
        ChangeState(GameState.Ready);
    }
}
