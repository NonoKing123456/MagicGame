using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject levelPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleOpenSetting()
    {
        settingPanel.SetActive(true);
        AudioManager.Instance.PlayButtonClick();
    }
    public void HandleStartFirstLevel()
    {
        GameSession.Instance.selectedLevel = 0;
        SceneManager.LoadScene("Level");
    }
    public void HandleOpenLevelPanel()
    {
        levelPanel.SetActive(true);
        AudioManager.Instance.PlayButtonClick();
    }
}
