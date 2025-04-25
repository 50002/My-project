using UnityEngine;

public class SpawniHallinta : MonoBehaviour
{
    public GameObject[] animalPrefabs; // Array of animal prefabs to spawn
    
    public float spawnPosZ = 20; // Z-coordinate for spawn position
    public float spawnRangeX = 10; // Range for random X-coordinate

     private float startDelay = 2f; // Delay before the first spawn
    private float spawnInterval = 1.5f; // Interval between spawns

    // Start is called before the first frame update
    void Start()
    {
        // Repeatedly call SpawnAnimal with a delay and interval
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
    }
    
     public void SpawnAnimal()
    {
       


        // Create a new spawn position with the random X-coordinate
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Generate a random index for the animal prefab
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Instantiate the selected animal prefab at the random spawn position
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
}


