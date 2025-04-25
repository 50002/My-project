using UnityEngine;

public class TuhooJosPoisNäytölt : MonoBehaviour
{
    private float topBound = 30; // Yläraja
    private float bottomBound = -10; // Alaraja
    private float sideBound = 30; // Sivurajat

    // Update is called once per frame
    void Update()
    {
        // Check if the object is out of bounds on the z-axis
        if (transform.position.z > topBound)
        {
            Destroy(gameObject); // Destroy the object if it goes above the top boundary
        }
        else if (transform.position.z < bottomBound)
        {
            
            Destroy(gameObject); // Destroy the object
        }
        // Check if the object is out of bounds on the x-axis
        else if (transform.position.x > sideBound || transform.position.x < -sideBound)
        {
            Destroy(gameObject); // Destroy the object if it goes beyond the side boundaries
        }
    }
}
