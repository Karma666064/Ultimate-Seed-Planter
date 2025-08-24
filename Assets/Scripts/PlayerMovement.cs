using UnityEngine;
using UnityEngine.InputSystem;

public class GreenbotController : MonoBehaviour
{
    [Header("Paramètres du Player")]
    public float moveSpeed = 6f;

    [Header("Inventaires")]
    public Inventory inventory;
    public WaterInventory waterInventory;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Déplacement clavier
        moveInput = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
            if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
            if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        }
        moveInput = moveInput.normalized;

        // Actions
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (inventory.UseSeed())
                Debug.Log("Graine plantée !");
            else
                Debug.Log("Plus de graines !");
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (waterInventory.UseWater())
                Debug.Log("Plante arrosée !");
            else
                Debug.Log("Plus d'eau !");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
