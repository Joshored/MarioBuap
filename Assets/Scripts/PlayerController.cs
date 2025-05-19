using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;       // Un punto para detectar si está tocando el suelo
    public float checkRadius = 0.2f;    // Radio para la detección
    public LayerMask whatIsGround;      // Define qué es suelo

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Voltear sprite según dirección
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // Detección de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Actualizar animaciones
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isJumping", !isGrounded);
    }
}

