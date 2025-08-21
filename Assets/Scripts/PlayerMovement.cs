using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parametre du Player")]
    public float moveSpeed = 6f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Catch the rigidbody component of the player component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        // Déplacement clavier
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) { moveInput.y += 1; }
            if (Keyboard.current.aKey.isPressed) { moveInput.x -= 1; } 
            if (Keyboard.current.sKey.isPressed) { moveInput.y -= 1; }
            if (Keyboard.current.dKey.isPressed) { moveInput.x += 1; }
        }

        // Evite la diagonale plus rapide
        moveInput = moveInput.normalized;
    }
    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
