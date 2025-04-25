using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput; // Variable to store horizontal input
    public float speed = 10f; // Speed of the player
    public float xBound = 10f; // Boundary limit for the player's position on the x-axis

    public GameObject projectilePrefab; // Reference to the projectile prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (A/D or Left/Right arrow keys)
        horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

        // Apply movement to the player's position
        transform.Translate(movement);

        // Prevent the player from going out of bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xBound, xBound); //Clamp Pitää huolta siitä että pelaaja pysyy -xBound ja xBound välillä
        transform.position = clampedPosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation); // Luo Viinipullon pelaajan sijaintiin
        }
    }
}