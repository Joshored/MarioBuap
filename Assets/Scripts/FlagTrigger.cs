using UnityEngine;

public class FlagTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Mario tocó la bandera!");
            MarioController mario = other.GetComponent<MarioController>();
            if (mario != null)
            {
                mario.ActivateFlagAnimation();
            }
        }
    }
}
