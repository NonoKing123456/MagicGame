using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    private int row;
    private bool dying;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitClip;
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (dying) return;
        transform.Translate(Vector3.right * speed);
    }
    public void SetRow(int row)
    {
        this.row = row;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.GetComponent<Enemy>().GetRow() == row && !other.GetComponent<Enemy>().IsDying() && !dying)
        {
            other.GetComponent<Enemy>().TakeDamage(1); 
            animator.SetTrigger("Hit");
            dying = true;
            audioSource.PlayOneShot(hitClip);
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
