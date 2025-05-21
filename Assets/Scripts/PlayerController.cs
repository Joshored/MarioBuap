using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;
    public float runMultiplier = 1.7f;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded;
    private float moveInput;

    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        // Movimiento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Z))
        {
            currentSpeed *= runMultiplier;
        }

        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);

        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("isJumping", !isGrounded);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        anim.SetTrigger("Die");   // Asegúrate de tener este trigger en el Animator
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;

        // Opcional: recargar escena tras delay para reiniciar juego
        Invoke(nameof(RestartScene), 1.5f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private bool hasReachedFlag = false;

    public void ActivateFlagAnimation()
    {
        if (hasReachedFlag) return;

        hasReachedFlag = true;

        anim.Play("Celebrate");  // Reemplaza "Celebrate" por el nombre exacto de la animación en tu Animator
        rb.velocity = Vector2.zero;  // Detener movimiento
        this.enabled = false;        // Desactivar el script para evitar más input de jugador
    }

}

