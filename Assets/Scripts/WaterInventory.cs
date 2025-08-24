using UnityEngine;

public class WaterInventory : MonoBehaviour
{
    public int maxWater = 10;
    public int currentWater = 10;

    public void RefillWater()
    {
        currentWater = maxWater;
    }

    public bool UseWater()
    {
        if (currentWater > 0)
        {
            currentWater--;
            return true;
        }
        return false;
    }
}
