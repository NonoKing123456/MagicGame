using UnityEngine;

public class Mana : MonoBehaviour
{
    
    Vector3 targetPosition;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 1f;
    [SerializeField] private float idleTime;
    [SerializeField] private float returnTime;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = Camera.main.ScreenToWorldPoint(ManaManager.Instance.transform.position);
        returnTime = Time.time + idleTime;
    }
    void Update()
    {
        if (Time.time >= returnTime)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, targetPosition) < distance)
        {
            ManaManager.Instance.AddMana(25);
            Destroy(gameObject);
        }
    }
    
}
