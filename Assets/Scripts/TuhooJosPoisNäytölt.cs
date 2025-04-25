using UnityEngine;

public class TuhooJosPoisNäytölt : MonoBehaviour
{
    private float topBound = 30; // Yläraja
    private float bottomBound = -10; // Alaraja

    // Update is called once per frame
    void Update()
    {
        // Check if the object is out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject); // Destroy the object if it goes above the top boundary
        }
        else if (transform.position.z < bottomBound)
        {
            Debug.Log("Game Over"); // Log "Game Over" if the object goes below the bottom boundary
            Destroy(gameObject); // Destroy the object
        }
    }
}
