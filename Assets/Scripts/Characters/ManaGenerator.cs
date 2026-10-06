using UnityEngine;

public class ManaGenerator : MonoBehaviour
{
    [SerializeField] private float manaGenerateInterval;
    [SerializeField] private float manaGenerateRandomRange;
    [SerializeField] private GameObject ManaPrefab;
    private float nextManaGenerateTime;
    void Awake()
    {
        setNextTime();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Victory) return;
        if (Time.time >= nextManaGenerateTime)
        {
            GenerateMana();
            setNextTime();
        }
    }

    private void GenerateMana()
    {
        //Debug.Log("Mana generated");
        Instantiate(ManaPrefab, transform.position, Quaternion.identity);
    }

    private void setNextTime()
    {
        nextManaGenerateTime = Time.time + manaGenerateInterval + Random.Range(manaGenerateInterval - manaGenerateRandomRange, manaGenerateInterval + manaGenerateRandomRange); //Generate random time between manaGenerateInterval - manaGenerateRandomRange and manaGenerateInterval + manaGenerateRandomRange
    }
}
