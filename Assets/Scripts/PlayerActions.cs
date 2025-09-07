using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    private PlayerInventory inventory;
    private PlayerTriggers triggers;
    private PlayerInput input;
    private Rigidbody2D rb;

    public GameObject terreLabourer;
    public int maxDistance = 4;

    Tilemap tilemap;
    Vector2 mousePos;

    public GameObject actualTiles;
    public enum Tools { Hoe, SeedBag, WateringCan}
    public Tools tools;
    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        triggers = GetComponent<PlayerTriggers>();
        rb = GetComponent<Rigidbody2D>();
    }

    //void Update()
    //{
    //    // Actions avec le nouveau Input System
    //    if (Keyboard.current != null)
    //    {
    //        //if (triggers.nearWater && Keyboard.current.eKey.wasPressedThisFrame)
    //        //{
    //        //    inventory.RefillWater();
    //        //}

    //    }
    //}

    public void Mouse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 mouseScreenPos = Input.mousePosition;
            
            mousePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            Debug.Log(mousePos);

            Plant(mousePos);

        }
    }

    public void Plant(Vector3 worldPos)
    {
        Vector3 spawnPos = Vector3.zero;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(worldPos.x, worldPos.y), -Vector2.up);

        // Récuperer la tiles
        if (hit)
        {
            actualTiles = hit.collider.gameObject;
            tilemap = hit.collider.gameObject.GetComponent<Tilemap>();

            if (tilemap != null)
            {
                Vector3Int cell = tilemap.WorldToCell(hit.point);
                Vector2 playerPos = rb.position;

                spawnPos = tilemap.GetCellCenterWorld(cell);

                if (Vector2.Distance(playerPos, spawnPos) > maxDistance)
                {
                    return;
                }

                // check position du perso et si ya terreLabourrer avec le spawnPos
            }
            else { return; }
        }

        if (tools == Tools.Hoe)
        {
            Instantiate(terreLabourer, spawnPos, Quaternion.identity);
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
