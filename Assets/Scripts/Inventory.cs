using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int seedCount = 5; // Commence avec 5 graines
    public int maxWater = 10;
    public int currentWater = 10;
    public Inventory inventory;
    public TMP_Text seedText;
    public TMP_Text waterText;

    void Update()
    {
        seedText.text = "Seeds: " + inventory.seedCount;
        waterText.text = "Water: " + currentWater + "/" + maxWater;
    }

    public void AddSeeds(int amount)
    {
        seedCount += amount;
    }

    public void RefillWater()
    {
        currentWater = maxWater;
    }

    public bool UseSeed()
    {
        if (seedCount > 0)
        {
            seedCount--;
            return true;
        }
        else return false;
    }
    public bool UseWater()
    {
        if (currentWater > 0)
        {
            currentWater--;
            return true;
        }
        else return false;
    }
}
