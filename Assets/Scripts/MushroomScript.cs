using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public float speed = 1.5f;
    public bool moveLeft;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);

        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameObject"))
        {
            if (moveLeft)
            {
                moveLeft = false;

            }
            else
            {
                moveLeft = true;
            }

        }

        if(collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            collision.gameObject.GetComponent<MarioController>().growUp = true;
        }

       
    }
}
