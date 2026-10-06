using UnityEngine;
using TMPro;
using System;

public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance;
    [SerializeField] private int currentMana;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    public bool CanAfford(int cost)
    {
        return currentMana >= cost;
    }
    public void SpendMana(int cost)
    {
        if (CanAfford(cost))
        {
            currentMana -= cost;
        }
    }
    private void UpdateText()
    {
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = currentMana.ToString();
    }

    internal void AddMana(int v)
    {
        currentMana += v;
    }
    internal void SetMana(int mana)
    {
        currentMana = mana;
    }
}
