using UnityEngine;

public class AutoCameraMoverFocusTop : MonoBehaviour
{
    public Transform[] planets;    // Array of planets' positions
    public float speed = 5f;       // Speed of camera movement
    public float viewDistance = 10f; // Distance to stay from each planet
    public float heightOffset = 5f;  // How much higher than the planet's top to place the camera
    public float rotationSpeed = 2f; // Speed of camera rotation (new variable)
    private int currentPlanet = 0;  // Track the current planet being viewed
    private bool isMoving = true;   // Determines if the camera should move

    void Update()
    {
        // Ensure there are planets assigned
        if (planets.Length == 0)
            return;

        // Continue moving if movement is allowed
        if (isMoving)
        {
            MoveTowardsPlanet();
        }
    }

    // Move the camera towards the current planet, focusing on the top and maintaining distance
    void MoveTowardsPlanet()
    {
        if (currentPlanet >= 0 && currentPlanet < planets.Length)
        {
            // Get the current planet's position
            Vector3 planetPosition = planets[currentPlanet].position;

            // Calculate the direction from the camera to the planet (ignoring height)
            Vector3 directionToPlanet = (planetPosition - transform.position).normalized;

            // Adjust the target position to stay at a certain distance and above the planet
            Vector3 targetPosition = planetPosition - directionToPlanet * viewDistance;

            // Raise the camera to focus on the top of the planet (Y-axis offset)
            targetPosition.y += heightOffset;

            // Move the camera towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Smoothly rotate the camera towards the planet
            Quaternion targetRotation = Quaternion.LookRotation(planetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the camera has reached close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // When the camera reaches the target distance, move to the next planet
                NextPlanet();
            }
        }
    }

    // Switch to the next planet in the array
    void NextPlanet()
    {
        // Move to the next planet in the list, and stop if it's the last one
        currentPlanet++;

        if (currentPlanet >= planets.Length)
        {
            // Stop movement after all planets have been viewed
            isMoving = false;
        }
    }
}
