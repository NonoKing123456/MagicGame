using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelCatalog", menuName = "Scriptable Objects/LevelCatalog")]
public class LevelCatalog : ScriptableObject
{
    [System.Serializable]
    public class LevelData
    {
        public int initMana;
        public float firstWaveTime;
        public string levelName;
        public int waveCount;
        public float waveInterval;
        public Wave[] waves;
    }
    [System.Serializable]
    public class Wave
    {
        public int[] enemies;
    }
    public LevelData[] levelData;
    
}
