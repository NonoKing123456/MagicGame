using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private AudioClip plantedClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip selectCardClip;
    public AudioMixerGroup MusicGroup => musicGroup;
    public AudioMixerGroup SFXGroup => sfxGroup;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        musicSource.outputAudioMixerGroup = musicGroup;
        sfxSource.outputAudioMixerGroup = sfxGroup;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayPlantedSFX()
    {
        sfxSource.PlayOneShot(plantedClip);
    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    internal void PlayButtonClick()
    {
        sfxSource.PlayOneShot(clickClip);
    }
    public void PlaySelectCard()
    {
        sfxSource.PlayOneShot(selectCardClip);
    }
}
