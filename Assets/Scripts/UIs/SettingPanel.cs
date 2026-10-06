using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SettingPanel : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        SetupValues();
    }
    
    private void SetupValues()
    {
        musicVolumeSlider.value = GameSession.Instance.MusicVolume;
        sfxVolumeSlider.value = GameSession.Instance.SFXVolume;
    }
    public void HandleResume(){
        GameManager.Instance.Resume();
        AudioManager.Instance.PlayButtonClick();
    }
    public void HandlePause(){
        GameManager.Instance.Pause();
        AudioManager.Instance.PlayButtonClick();
    }
    public void HandleRestart(){
        GameManager.Instance.Restart();
        AudioManager.Instance.PlayButtonClick();
    }
    public void HandleQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void SetMusicVolume(float volume)
    {
        GameSession.Instance.MusicVolume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        GameSession.Instance.SFXVolume = volume;
    }
    public void HandleQuitGame()
    {
        Application.Quit();
    }
    public void HandleCloseSetting()
    {
        gameObject.SetActive(false);
        AudioManager.Instance.PlayButtonClick();
    }
    public void HandleBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.Instance.PlayButtonClick();
    }
}
