using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    public Transform orbitCenter;  // The object the satellite will orbit around
    public float orbitRadius = 10f; // The radius of the orbit
    public float orbitSpeed = 30f;  // Speed of the orbit (degrees per second)

    private float angle;  // Current angle of the satellite in the orbit

    void Update()
    {
        // Increment the angle based on the orbit speed
        angle += orbitSpeed * Time.deltaTime;
        
        // Convert the angle to radians for circular motion
        float radians = angle * Mathf.Deg2Rad;

        // Calculate the new position of the satellite based on the orbit center and radius
        float x = orbitCenter.position.x + orbitRadius * Mathf.Cos(radians);
        float z = orbitCenter.position.z + orbitRadius * Mathf.Sin(radians);

        // Set the new position of the satellite (Sputnik)
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
