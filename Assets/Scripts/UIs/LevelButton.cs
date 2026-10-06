using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    private Button button;
    private TextMeshProUGUI label;
    private TextMeshProUGUI levelName;
    void Awake()
    {
        button = GetComponent<Button>();
        label = transform.Find("text").GetComponent<TextMeshProUGUI>();
        levelName = transform.Find("LevelName").GetComponent<TextMeshProUGUI>();
        button.onClick.AddListener(OnClick);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLevelIndex(int index)
    {
        levelIndex = index;
        UpdateLabel();
    }
    private void UpdateLabel()
    {
        label.text = (levelIndex + 1).ToString();
    }
    private void OnDestroy()
    {
        if (button != null) button.onClick.RemoveListener(OnClick);
    }
    public void OnClick()
    {
        GameSession.Instance.selectedLevel = levelIndex;
        SceneManager.LoadScene("Level");
    }
    public void SetLevelName(string name)
    {
        levelName.text = name;
    }
}
