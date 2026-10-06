using UnityEngine;
using UnityEngine.UI;
public class LevelPanel : MonoBehaviour
{
    [SerializeField] private LevelCatalog levelCatalog;
    [SerializeField] private int levelCount;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private RectTransform initPosition;
    [SerializeField, Min(1)] private int columns = 4;
    [SerializeField] private Vector2 buttonSpacing = new Vector2(100f, 100f);
    private bool initialized;
    void Awake()
    {
        levelCount = levelCatalog.levelData.Length;
    }
    void OnEnable()
    {
        if (initialized) return;
        Vector3 startPosition = transform.InverseTransformPoint(initPosition.position);
        for (int i = 0; i < levelCount; i++)
        {
            //Debug.Log("Level " + (i + 1));
            GameObject levelButton = Instantiate(levelButtonPrefab, transform, false);
            levelButton.transform.localPosition = startPosition + new Vector3(
                (i % Mathf.Max(1, columns)) * buttonSpacing.x,
                -(i / Mathf.Max(1, columns)) * buttonSpacing.y, 0f);
            LevelButton levelButtonComponent = levelButton.GetComponent<LevelButton>();
            levelButtonComponent.SetLevelIndex(i);
            levelButtonComponent.SetLevelName(levelCatalog.levelData[i].levelName);
        }
        initialized = true;
    }
    public void HandleClose()
    {
        gameObject.SetActive(false);
        AudioManager.Instance.PlayButtonClick();
    }
}
