using UnityEngine;

public class RotateSun : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 10.0f;

    void Update()
    {
        // Rotate around the Y axis (you can change Vector3.up to other axes if needed)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
