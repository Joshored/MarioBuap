using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Mario
    public float smoothSpeed = 0.125f;
    public Vector3 offset;         // Ajustaremos este para poner a Mario a la izquierda

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, offset.y, transform.position.z);
    }
}
