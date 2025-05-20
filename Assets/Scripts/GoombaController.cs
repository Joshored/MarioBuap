using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool movingLeft = true;

    public Transform groundCheck;
    public float detectionDistance = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.relativeVelocity.y > 0) // Mario lo pisa
            {
                Destroy(gameObject);
                Rigidbody2D marioRb = collision.gameObject.GetComponent<Rigidbody2D>();
                marioRb.velocity = new Vector2(marioRb.velocity.x, 10f); // rebote
            }
            else
            {
                Debug.Log("Mario golpeado por el lado");
                // Aquí podrías restarle una vida, cambiar de escena, etc.
            }
        }
    }
}
