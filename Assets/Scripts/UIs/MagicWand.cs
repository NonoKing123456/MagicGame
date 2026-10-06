using UnityEngine;

public class MagicWand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectWand()
    {
        PlacementController.Instance.SelectWand();
    }
}
