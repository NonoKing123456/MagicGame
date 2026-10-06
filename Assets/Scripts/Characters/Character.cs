using System;
using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int characterID;
    [SerializeField] private string characterName;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    // [row, column]. A character that has not been placed has no valid cell.
    [SerializeField] private int[] plantedGrid = new int[] { -1, -1 };
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private bool dying;
    [SerializeField] private float dyingTime;
    [SerializeField] private float fadeOutTime = 0.5f;
    [SerializeField] private float cooldownTime;
    [SerializeField] private int manaCost;
    [SerializeField] private CharacterAudio characterAudio;
    public string CharacterName => characterName;
    public float CooldownTime => cooldownTime;
    public int ManaCost => manaCost;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        characterAudio = GetComponent<CharacterAudio>();
    }
    public int GetCharacterID()
    {
        return characterID;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>Stores [row, column], matching BattleGrid and EnemyManager.</summary>
    public void SetPlantedGrid(int[] grid)
    {
        plantedGrid = grid;
    }
    public int[] GetPlantedGrid()
    {
        return plantedGrid;
    }

    internal void TakeDamage(int damage)
    {
        currentHealth -= damage;
        spriteRenderer.color = Color.red;
        Invoke(nameof(ResetColor), 0.2f);
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            dying = true;
            characterAudio.PlayDie();
            Invoke(nameof(ClearCorpse), dyingTime);
            BattleGrid.Instance.RemoveCharacter(this);
        }
    }
    private void ClearCorpse()
    {
        StartCoroutine(FadeOutCoroutine(fadeOutTime));
    }
    private void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }
    public bool IsDying() => dying;
    private IEnumerator FadeOutCoroutine(float time)
    {
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / time;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            yield return null;
        }
        Destroy(gameObject);
    }
}
