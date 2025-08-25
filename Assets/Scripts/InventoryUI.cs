using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public WaterInventory waterInventory;
    public TMP_Text seedText;
    public TMP_Text waterText;

    void Update()
    {
        seedText.text = "Seeds: " + inventory.seedCount;
        waterText.text = "Water: " + waterInventory.currentWater + "/" + waterInventory.maxWater;
    }
}
