using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput; // Variable to store horizontal input
    float verticalInput; // Variable to store vertical input
    public float speed = 10f; // Speed of the player
    public float bound = 10f; // Boundary limit for the player's position on the x-axis

    public GameObject projectilePrefab; // Reference to the projectile prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical input (A/D or Left/Right arrow keys, W/S or Up/Down arrow keys)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Calculate movement
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        // Apply movement to the player's position
        transform.Translate(movement);

        // Prevent the player from going out of bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -bound, bound); // Clamp x-axis
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, 0, 15); // Clamp z-axis
        transform.position = clampedPosition;

        // Instantiate projectile on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); // Spawn projectile at player's position
        }
    }
}