using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField] private List<Enemy>[] enemyLanes;
    [SerializeField] private Vector2[] spawnPoints;
    [SerializeField] private Vector2 spawnOffset;
    [SerializeField] private UnitCatalog unitCatalog;
    [SerializeField] private LevelCatalog levelCatalog;
    [SerializeField] private LevelCatalog.LevelData currentLevel;
    [SerializeField] private int nextEnemyOrder = 1;
    [SerializeField] private float firstWaveTime;
    [SerializeField] private float waveInterval;
    [SerializeField] private int deadEnemyCount;
    [SerializeField] private int totalEnemyCount;
    // Awake方法在游戏对象初始化时调用，用于进行初始化设置
    private void Awake()
    {
        // 初始化当前关卡索引为0
        // 检查单例实例是否为空
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            // 如果单例实例已存在且不等于当前实例，则销毁当前游戏对象
            return;
            // 提前返回，避免执行后续代码
        }
    }

    // All Awake calls finish before Start, so BattleGrid has initialized its corners.
    void Start()
    {
    }

    public void InitGridsAndLevel()
    {
        StopEnemySpawning();
        BattleGrid grid = BattleGrid.Instance;
        if (grid == null || grid.gridEdges == null || grid.gridEdges.Length != 4 || grid.VerticalGridCount <= 0)
        {
            Debug.LogError("EnemyManager requires an initialized BattleGrid.", this);
            return;
        }

        enemyLanes = new List<Enemy>[grid.VerticalGridCount];
        for (int i = 0; i < enemyLanes.Length; i++)
        {
            enemyLanes[i] = new List<Enemy>();
        }
        spawnPoints = new Vector2[grid.VerticalGridCount];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float rowCenter = (i + 0.5f) / grid.VerticalGridCount;
            spawnPoints[i] = Vector2.Lerp(grid.gridEdges[1], grid.gridEdges[3], rowCenter) + spawnOffset;
        }
        deadEnemyCount = 0;
        currentLevel = GameManager.Instance.CurrentLevelData;
        firstWaveTime = currentLevel.firstWaveTime;
        waveInterval = currentLevel.waveInterval;
        totalEnemyCount = 0;
        deadEnemyCount = 0;
        // 安排每一波敌人的生成时间
        for (int i = 0; i < currentLevel.waves.Length; i++)
        {
            int waveIndex = i;
            totalEnemyCount += currentLevel.waves[i].enemies.Length;
            StartCoroutine(DelaySpawn(i * waveInterval + firstWaveTime, () => SpawnWave(waveIndex)));
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnWave(int waveIndex)
    {
        Debug.Log("Spawning wave " + waveIndex);
        if (currentLevel != null && waveIndex >= 0 && waveIndex < currentLevel.waves.Length)
        {
            LevelCatalog.Wave wave = currentLevel.waves[waveIndex];
            for (int i = 0; i < wave.enemies.Length; i++)
            {
                float delay = Random.Range(0f, 1f);
                int enemyIndex = wave.enemies[i];
                StartCoroutine(DelaySpawn(delay, () => SpawnEnemy(Random.Range(0, spawnPoints.Length), enemyIndex)));
            }
        }
    }
    // Keep both wave and individual spawn timers on this manager so they can be cancelled together.
    private IEnumerator DelaySpawn(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private void SpawnEnemy(int lane, int enemyIndex)
    {
        GameObject enemyGO = Instantiate(unitCatalog.GetEnemyUnit(enemyIndex), spawnPoints[lane], Quaternion.identity);
        enemyGO.GetComponent<SpriteRenderer>().sortingOrder = nextEnemyOrder++;
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.SetRow(lane);
        enemyLanes[lane].Add(enemy);
    }

    internal bool HasEnemiesAtFront(int[] plantedGrid, Transform characterTransform)
    {
        // Scene characters and freshly created objects may not have a cell yet.
        if (plantedGrid == null || plantedGrid.Length != 2 || enemyLanes == null) return false;
        int row = plantedGrid[0];
        int column = plantedGrid[1];
        if (row < 0 || row >= enemyLanes.Length || column < 0) return false;

        List<Enemy> enemies = enemyLanes[row];
        if (enemies == null || characterTransform == null) return false;
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];
            if (enemy != null && enemy.transform.position.x > characterTransform.position.x)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveEnemy(Enemy enemy)
    {
        if (enemy == null) return;
        int lane = enemy.GetRow();
        if (lane >= 0 && lane < enemyLanes.Length)
        {
            enemyLanes[lane].Remove(enemy);
        }
        deadEnemyCount++;
        if (deadEnemyCount >= totalEnemyCount)
        {
            //游戏胜利！
            GameManager.Instance.WinGame();
        }
    }
    public void StopEnemySpawning()
    {
        StopAllCoroutines();
    }

    public void RemoveAllEnemmySpawning()
    {
        StopEnemySpawning();
        enemyLanes = null;
        nextEnemyOrder = 0;
        currentLevel = null;
        spawnPoints = null;
        waveInterval = 0f;
        firstWaveTime = 0f;
    }
}
