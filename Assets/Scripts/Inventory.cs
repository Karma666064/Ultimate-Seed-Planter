using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int seedCount = 5; // Commence avec 5 graines

    public void AddSeeds(int amount)
    {
        seedCount += amount;
    }

    public bool UseSeed()
    {
        if (seedCount > 0)
        {
            seedCount--;
            return true;
        }
        return false;
    }
}
