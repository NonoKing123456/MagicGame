using System;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private Character self;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Vector2 projectileSpawnPointOffSet;
    [SerializeField] private float projectilInterval;
    [SerializeField] private float nextProjectTime;
    [SerializeField] private float attackPrepareTime;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterAudio characterAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        self = GetComponent<Character>();
        animator = GetComponent<Animator>();
        characterAudio = GetComponent<CharacterAudio>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (self != null && EnemyManager.Instance != null
            && EnemyManager.Instance.HasEnemiesAtFront(self.GetPlantedGrid(), transform))
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        if (Time.time >= nextProjectTime)
        {
            Invoke(nameof(ShootProjectile), attackPrepareTime);
            animator.SetTrigger("Attack");
            nextProjectTime = Time.time + projectilInterval;
        }
    }

    private void ShootProjectile()
    {
        GameObject gameObject = Instantiate(projectile, transform.position + (Vector3)projectileSpawnPointOffSet, Quaternion.identity);
        gameObject.GetComponent<Projectile>().SetRow(self.GetPlantedGrid()[0]);
        characterAudio.PlayAttack();
    }
    private void OnDrawGizmos()
    {
        if (projectileSpawnPointOffSet != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + (Vector3)projectileSpawnPointOffSet, 0.1f);
        }
    }
}
