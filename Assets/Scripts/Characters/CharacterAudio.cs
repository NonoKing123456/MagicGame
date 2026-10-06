using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip hurtClip;
    [SerializeField] AudioClip dieClip;
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
        audioSource.clip = attackClip;
        audioSource.Play();
    }
    public void PlayHurt()
    {
        audioSource.clip = hurtClip;
        audioSource.Play();
    }
    public void PlayDie()
    {
        if (dieClip == null) return;
        audioSource.clip = dieClip;
        audioSource.Play();
    }
}
