
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothePosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothePosition;
    }
}
