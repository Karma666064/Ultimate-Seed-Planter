using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parametre du Player")]
    public float moveSpeed = 6f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDir;
    private Animator animator;

    void Start()
    {
        // Catch the rigidbody component of the player component
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Vector2.zero;

        // Déplacement clavier
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                moveInput.y += 1;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                moveInput.x -= 1;
            } 
            if (Keyboard.current.sKey.isPressed)
            {
                moveInput.y -= 1;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                moveInput.x += 1;
            }
        }

        // Evite la diagonale plus rapide
        moveInput = moveInput.normalized;

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
    }
    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
