using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PlacementController : MonoBehaviour
{
    public static PlacementController Instance;
    [SerializeField] private BattleGrid battleGrid;
    [SerializeField] private Canvas canvas;
    [SerializeField] private CharacterCard selectedCard;
    [SerializeField] private Sprite wandPreviewSprite; // the sprite of the wand preview
    [SerializeField] private GameObject movablePreviewObject;
    [SerializeField] private GameObject fixedPreview;
    [SerializeField] private int[] hoveredCell = new int[] { -1, -1 }; // [row, column]
    [SerializeField] private bool selecting; // true if the player is selecting a character to place
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }

        canvas = FindAnyObjectByType<Canvas>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (selecting)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            int[] newHoveredCell = battleGrid.FindCellByPosition(mouseWorldPos);
            int row = newHoveredCell[0];
            int column = newHoveredCell[1];
            movablePreviewObject.transform.position = new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0);
            if (row == -1 || column == -1)
            {
                if (fixedPreview != null)
                {
                    Destroy(fixedPreview);
                    fixedPreview = null;
                }
            }
            else
            {
                if (fixedPreview == null && selectedCard != null){
                    fixedPreview = CreatePreview();
                }
                if (fixedPreview != null)
                {
                fixedPreview.transform.position = Camera.main.WorldToScreenPoint(battleGrid.GetCellPosition(row, column));
                }
            }
            hoveredCell = newHoveredCell;
            if (Mouse.current.leftButton.wasPressedThisFrame){
                if (row != -1 && column != -1 && !battleGrid.GetCellPlanted(row, column))
                {
                    if (selectedCard != null)
                    {
                        battleGrid.SetCell(row, column, selectedCard.character);
                        ManaManager.Instance.SpendMana(selectedCard.ManaCost);
                        selectedCard.startCooldown();
                    }
                }else if (selectedCard == null)
                {
                    battleGrid.RemoveCell(row, column);
                }
                selecting = false;
                selectedCard = null;
                Destroy(movablePreviewObject);
                Destroy(fixedPreview);
                fixedPreview = null;
                movablePreviewObject = null;
            }
                
        }
    }
    public void Select(CharacterCard characterCard)
    {
        if (selectedCard != null || selecting) return;
        selectedCard = characterCard;
        selecting = true;
        movablePreviewObject = CreatePreview();
        AudioManager.Instance.PlaySelectCard();
    }

    public void SelectWand()
    {
        if (selectedCard != null || selecting) return;
        selectedCard = null;
        selecting = true;
        movablePreviewObject = CreatePreview();
    }

    private GameObject CreatePreview()
    {
        GameObject previewObject = new GameObject("Preview");
        previewObject.transform.SetParent(canvas.transform, false);
        previewObject.AddComponent<Image>();
         
        previewObject.GetComponent<Image>().sprite = selectedCard != null ? selectedCard.previewSprite : wandPreviewSprite;
        Color32 color32 = previewObject.GetComponent<Image>().color;
        color32.a = 128; // 0.5f in 0-255 range
        previewObject.GetComponent<Image>().color = color32;
        previewObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        previewObject.GetComponent<Image>().preserveAspect = true;
        return previewObject;
    }
}
