using UnityEngine;
using UnityEngine.InputSystem;

public class GreenbotController : MonoBehaviour
{
    [Header("Param�tres du Player")]
    public float moveSpeed = 6f;

    [Header("Inventaires")]
    public Inventory inventory;
    public WaterInventory waterInventory;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDir;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // D�placement clavier
        moveInput = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.aKey.isPressed) moveInput.x -= 1; 
            if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
            if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
        }
        moveInput = moveInput.normalized;

        // Animation controller
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", moveInput.x);
            animator.SetFloat("moveY", moveInput.y);

            lastMoveDir = moveInput;
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("moveX", lastMoveDir.x);
            animator.SetFloat("moveY", lastMoveDir.y);
        }

        // Actions
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (inventory.UseSeed())
                Debug.Log("Graine plant�e !");
            else
                Debug.Log("Plus de graines !");
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (waterInventory.UseWater())
                Debug.Log("Plante arros�e !");
            else
                Debug.Log("Plus d'eau !");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
