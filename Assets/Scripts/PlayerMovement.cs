using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parametre du Player")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Catch the rigidbody component of the player component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Catch the inputs for the x & y axis deplacements
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the values
        moveInput = moveInput.normalized;
    }
    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveInput);
    }
}
