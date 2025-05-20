using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public float runMultiplier = 1.7f;


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
        if (hasReachedFlag)
            return;

        // Movimiento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        float currentSpeed = speed;

        // Si se mantiene presionada la tecla Shift o Z, correr
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Z))
        {
            currentSpeed *= runMultiplier;
        }

        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);


        // Voltear sprite según dirección
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // Detección de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("¡Salto!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Actualizar animaciones
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isJumping", !isGrounded);
    }

    private bool hasReachedFlag = false;

    public void ActivateFlagAnimation()
    {
        anim.Play("Celebrate");
        rb.velocity = Vector2.zero; // Detén a Mario
        this.enabled = false;       // (Opcional) Desactiva controles
    }

}

