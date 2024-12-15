using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public float smoothSpeed = 0.125f;  // Smoothing speed for camera movement
    public Vector3 offset;  // Offset between the player and the camera

    void LateUpdate()
    {
        // Desired position of the camera based on the player's position and the offset
        Vector3 desiredPosition = player.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
