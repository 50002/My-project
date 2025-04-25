using UnityEngine;

public class Kuolema : MonoBehaviour
{
    private int lives = 3; // Player starts with 3 lives

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Animal" tag
        if (other.CompareTag("Animal"))
        {
            // Destroy the animal object
            Destroy(other.gameObject);

            // Decrease lives by 1
            lives--;

            // Print the remaining lives
            Debug.Log("HP: " + lives);

            // Check if no lives remain
            if (lives <= 0)
            {
                Debug.Log("Game over!");
                Destroy(gameObject); // Destroy the player
            }
        }
    }
}
