using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float nextAttackTime;
    [SerializeField] private float attackPrepareTime;
    [SerializeField] private Character attackingCharacter;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hurtColor = Color.red;
    [SerializeField] private Animator animator;
    [SerializeField] private bool dying = false;
    [SerializeField] private EnemyAudio enemyAudio;
    public float Speed => speed;
    public int MaxHealth => maxHealth;
    public int Health => health;
    private int row;
    public int GetRow() => row;
    public void SetRow(int row)
    {
        this.row = row;
    }
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyAudio = GetComponent<EnemyAudio>();
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        enemyAudio.PlayHurt();
        if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("Die");
            dying = true;
            rigidbody2D.linearVelocity = Vector2.zero;
        }
        spriteRenderer.color = hurtColor;
        Invoke(nameof(ResetColor), 0.2f);
    }
    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }
    private void ClearCorpse()
    {
        StartCoroutine(FadeOutCoroutine(0.5f));
        EnemyManager.Instance.RemoveEnemy(this);
    }

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

    void FixedUpdate()
    {
        UpdateMoves();
        UpdateAttacks();
    }

    private void UpdateMoves()
    {
        if (dying) return;  
        if (attackingCharacter != null && !attackingCharacter.IsDying())
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }
        rigidbody2D.linearVelocity = new Vector2(-speed, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && other.GetComponent<Character>().GetPlantedGrid()[0] == row)
        {
            attackingCharacter = other.GetComponent<Character>();
        }
        if (other.CompareTag("Game Over Area"))
        {
            GameManager.Instance.GameOver();
        }
    }

    public bool IsDying() => dying;
    private void UpdateAttacks()
    {
        if (dying) return;
        if (Time.time >= nextAttackTime && attackingCharacter != null && !attackingCharacter.IsDying())
        {
            nextAttackTime = Time.time + attackCooldown;
            // Implement attack logic here
            Invoke(nameof(DealDamage), attackPrepareTime);
            animator.SetTrigger("Attack");
            enemyAudio.PlayAttack();
        }
        return;
    }
    private void DealDamage()
    {
        attackingCharacter.TakeDamage(damage);
    }
}
