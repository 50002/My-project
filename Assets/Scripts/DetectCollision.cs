using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements like Slider

public class DetectCollision : MonoBehaviour
{
    private int fullness; // Variable to track fullness
    private static int score = 0; // Static variable to track the score
    private Slider fullnessSlider; // Reference to the Slider component

    private void Start()
    {
        // Set fullness based on the tag
        if (CompareTag("Animal"))
        {
            fullness = Random.Range(0, 91); // Random value between 0 and 90 for animals
        }
        else
        {
            fullness = 98; // Default value of 98 for non-animal objects
        }

        // Search for a Slider component in the scene
        fullnessSlider = FindObjectOfType<Slider>();

        // If a slider is found, set its initial value to match fullness
        if (fullnessSlider != null)
        {
            fullnessSlider.value = fullness;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Always destroy the object if it has the "Wine" tag
        if (CompareTag("Wine"))
        {
            Destroy(gameObject);
            return; // Exit the method to prevent further checks
        }

        // Ensure the player is not destroyed
        if (!other.CompareTag("Player"))
        {
            // Increase the fullness value by 33
            fullness += 33;

            // Update the slider value if a slider is found
            if (fullnessSlider != null)
            {
                fullnessSlider.value = fullness;
            }

            // Check if fullness exceeds 99
            if (fullness > 99)
            {
                // If the object has the "Animal" tag, increase the score
                if (CompareTag("Animal"))
                {
                    score++;
                    Debug.Log("Score = " + score); // Log the updated score
                }

                // Destroy itself
                Destroy(gameObject);
            }

            // Check if the other object has the "Wine" tag and destroy it last
            if (other.CompareTag("Wine"))
            {
                Destroy(other.gameObject); // Destroy the other object
            }
        }
    }
}
