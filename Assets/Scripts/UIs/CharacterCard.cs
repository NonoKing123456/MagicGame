using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] public Character character;
    [SerializeField] private PlacementController placementController;
    [SerializeField] public Sprite previewSprite;
    [SerializeField] private int manaCost;
    [SerializeField] private string characterName;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private Image coolDownOverlay;

    void Awake()
    {
        characterName = character.CharacterName;
        previewSprite = character.transform.GetComponent<SpriteRenderer>().sprite;
        placementController = FindAnyObjectByType<PlacementController>();
        cooldownTime = character.CooldownTime;
        manaCost = character.ManaCost;
        transform.Find("Price").GetComponent<TextMeshProUGUI>().text = manaCost.ToString();
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = characterName;
        transform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = previewSprite;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAffordability();
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        coolDownOverlay.fillAmount = cooldownTimer / cooldownTime;
    }

    public void SelectCard()
    {
        if (!ManaManager.Instance.CanAfford(manaCost) || cooldownTimer > 0) return;
        placementController.Select(this);
    }

    private void UpdateAffordability()
    {
        // Implement logic to update the affordability of the card based on manaManager.CanAfford(manaCost)
        bool canAfford = ManaManager.Instance.CanAfford(manaCost);
        // Example: Change the color of the card to indicate affordability
        GetComponent<UnityEngine.UI.Image>().color = canAfford ? Color.white : Color.gray;
        transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().color = canAfford ? Color.white : Color.gray;
    }

    internal void startCooldown()
    {
        cooldownTimer = cooldownTime;
    }

    public int ManaCost => manaCost;
}
