using UnityEngine;

[CreateAssetMenu(fileName = "UnitCatalog", menuName = "Scriptable Objects/UnitCatalog")]
public class UnitCatalog : ScriptableObject
{
    [SerializeField] private GameObject[] characterUnits;
    [SerializeField] private GameObject[] enemyUnits;
    [SerializeField] private GameObject[] otherUnits;
    public GameObject GetCharacterUnit(int index)
    {
        return characterUnits[index];
    }

    public GameObject GetEnemyUnit(int index)
    {
        return enemyUnits[index];
    }

    public GameObject GetOtherUnit(int index)
    {
        return otherUnits[index];
    }
}
