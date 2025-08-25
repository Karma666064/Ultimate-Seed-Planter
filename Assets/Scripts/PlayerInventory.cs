using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Variable")]
    public int seedCount = 5;
    public int maxWater = 10;
    public int currentWater = 10;
    //public TMP_Text seedText;
    //public TMP_Text waterText;

    void Update()
    {
        //seedText.text = "Seeds: " + seedCount;
        //waterText.text = "Water: " + currentWater + "/" + maxWater;
    }

    public void AddSeeds(int amount)
    {
        seedCount += amount;
    }

    public void RefillWater()
    {
        if (currentWater == maxWater)
        {
            Debug.Log("Water is full!");
        }
        else
        {
            currentWater = maxWater;
            Debug.Log("Refill succesfully!");
        }
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
