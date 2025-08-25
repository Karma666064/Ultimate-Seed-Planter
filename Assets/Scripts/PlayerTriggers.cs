using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [HideInInspector] public bool nearWater = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        if (other.CompareTag("WaterZone"))
        {
            nearWater = true;
            Debug.Log("Le joueur est devant l’eau.");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterZone"))
        {
            nearWater = false;
            Debug.Log("Le joueur s’éloigne de l’eau.");
        }
    }
}
