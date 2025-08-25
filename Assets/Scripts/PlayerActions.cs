using UnityEngine;
using UnityEngine.InputSystem; // obligatoire pour le nouveau Input System

public class GreenbotActions : MonoBehaviour
{
    public Inventory inventory;

    void Update()
    {
        // Actions avec le nouveau Input System
        if (Keyboard.current != null)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (inventory.UseSeed())
                    Debug.Log("Graine plantée !");
                else
                    Debug.Log("Plus de graines !");
            }

            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                if (inventory.UseWater())
                    Debug.Log("Plante arrosée !");
                else
                    Debug.Log("Plus d'eau !");
            }
        }
    }
}
