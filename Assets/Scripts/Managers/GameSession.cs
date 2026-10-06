using UnityEngine;
using UnityEngine.Audio;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }
    public int selectedLevel = 0;
    public float MusicVolume = 1f;
    [SerializeField] AudioMixer audioMixer;
    public float SFXVolume = 1f;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAudioVolumes();
    }
    
    private void UpdateAudioVolumes()
    {
        if (MusicVolume == 0f)
        {
            audioMixer.SetFloat("Music Volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music Volume", Mathf.Log10(MusicVolume) * 20);
        }
        if (SFXVolume == 0f)
        {
            audioMixer.SetFloat("Sfx Volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("Sfx Volume", Mathf.Log10(SFXVolume) * 20);
        }
    }
}
