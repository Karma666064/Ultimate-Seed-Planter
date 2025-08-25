//using UnityEngine;
//using UnityEngine.InputSystem;

//public class WaterSource : MonoBehaviour
//{
//    public int refillAmount = 3; // Combien d'eau récupérée par collecte

//    private void OnTriggerStay2D(Collider2D other)
//    {
//        // Vérifie si c'est Greenbot
//        if (other.CompareTag("Player"))
//        {
//            // Appuie sur R pour récupérer l'eau
//            if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
//            {
//                WaterInventory waterInv = other.GetComponent<WaterInventory>();
//                if (waterInv != null)
//                {
//                    // Ajoute de l'eau sans dépasser le max
//                    waterInv.currentWater += refillAmount;
//                    if (waterInv.currentWater > waterInv.maxWater)
//                        waterInv.currentWater = waterInv.maxWater;

//                    Debug.Log("Eau collectée ! Actuelle : " + waterInv.currentWater);
//                }
//            }
//        }
//    }
//}
