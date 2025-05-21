using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool movingLeft = true;

    public Transform groundCheck;
    public float detectionDistance = 1f;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (groundCheck == null)
        {
            Debug.LogError("groundCheck no está asignado en " + gameObject.name);
        }
    }


    void Update()
    {
        if (isDead) return;

        if (groundCheck == null)
            return;  // Salir si no está asignado

        rb.velocity = new Vector2((movingLeft ? -1 : 1) * speed, rb.velocity.y);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, detectionDistance);
        if (!groundInfo.collider)
        {
            Flip();
        }
    }



    void Flip()
    {
        movingLeft = !movingLeft;
        transform.eulerAngles = new Vector3(0, movingLeft ? 0 : 180, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            // Detectar si Mario pisa desde arriba (usamos posición)
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = GetComponent<Collider2D>().bounds.center;

            if (contactPoint.y > center.y + 0.1f)
            {
                Die();
                Rigidbody2D marioRb = collision.gameObject.GetComponent<Rigidbody2D>();
                marioRb.velocity = new Vector2(marioRb.velocity.x, 10f); // rebote
            }
            else
            {
                collision.gameObject.GetComponent<MarioController>().Die();
            }
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 0.5f);  // Espera a que termine la animación
    }
}

