using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    private PlayerInventory inventory;
    private PlayerTriggers triggers;
    private PlayerInput input;
    Tilemap tilemap;
    public GameObject terreLabourer;

    Vector2 mousePos;

    public GameObject actualTiles;
    public enum Tools { Hoe, SeedBag, WateringCan}
    public Tools tools;
    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        triggers = GetComponent<PlayerTriggers>();
    }

    void Update()
    {
        // Actions avec le nouveau Input System
        if (Keyboard.current != null)
        {
            //if (triggers.nearWater && Keyboard.current.eKey.wasPressedThisFrame)
            //{
            //    inventory.RefillWater();
            //}

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (tools == Tools.Hoe)
                {
                    Instantiate(terreLabourer, Vector3.zero, Quaternion.identity);
                    //tilemap.SetTile()
                    Debug.Log("Plant a seed");
                }
                if (tools == Tools.SeedBag)
                {
                    Debug.Log("Plant a Seed Bag");
                }
                if (tools == Tools.WateringCan)
                {
                    Debug.Log("Plant a WateringCan");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2 (mousePos.x, mousePos.y), -Vector2.up);

        // Récuperer la tiles
        if (hit)
        {
            actualTiles = hit.collider.gameObject;
            //gridSelection = hit.collider.gameObject.GetComponent<GridSelection>();
        }
    }

    public void Mouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mousePos = context.ReadValue<Vector2>();
        }
    }
}
