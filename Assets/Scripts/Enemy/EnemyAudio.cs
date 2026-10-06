using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip walkingClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = AudioManager.Instance.SFXGroup;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAttack()
    {
        if (attackClip == null) return;
        audioSource.PlayOneShot(attackClip);
    }

    public void PlayHurt()
    {
        if (hurtClip == null) return;
        audioSource.PlayOneShot(hurtClip);
    }
    
    public void PlayWalking()
    {
        audioSource.PlayOneShot(walkingClip);
    }
}
