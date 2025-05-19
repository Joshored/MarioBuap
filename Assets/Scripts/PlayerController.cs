using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Movimiento
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Animaciones
        if (Mathf.Abs(moveInput) > 0.01f)
        {
            animator.Play("Mario_Walk"); // Usa el nombre exacto de tu animación de caminar
        }
        else
        {
            animator.Play("Mario_Idle"); // Usa el nombre exacto de tu animación de estar quieto
        }

        // Girar sprite dependiendo de la dirección
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("void"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (collision.CompareTag("brick"))
        {
            
            rb.velocity = Vector2.down * 5;
        }
    }

}