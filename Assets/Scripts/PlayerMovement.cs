using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvemnt : MonoBehaviour
{
    [Header("Paramètres du Player")]
    public float moveSpeed = 6f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDir;
    private Animator animator;
    private bool authorizeToMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (authorizeToMove)
        {
            moveInput = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) moveInput.y += 1;
            if (Input.GetKey(KeyCode.A)) moveInput.x -= 1;
            if (Input.GetKey(KeyCode.S)) moveInput.y -= 1;
            if (Input.GetKey(KeyCode.D)) moveInput.x += 1;

            moveInput = moveInput.normalized;

            Move();
        }

        //Animation controller
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

    public void Move()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
