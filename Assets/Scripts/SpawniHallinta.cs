using UnityEngine;

public class SpawniHallinta : MonoBehaviour
{
    public GameObject[] animalPrefabs; // Array of animal prefabs to spawn

    public float spawnPosZ = 20; // Z-coordinate for top spawn position
    public float spawnRangeX = 10; // Range for random X-coordinate
    public float spawnRangeZ = 10; // Range for random Z-coordinate (for left and right spawns)
    public float sideSpawnOffset = 10; // Offset for side spawns to make them further away

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
        // Randomly select a spawn side: 0 = top, 1 = right, 2 = left
        int spawnSide = Random.Range(0, 3);

        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        if (spawnSide == 0) // Top
        {
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            spawnRotation = Quaternion.Euler(0, 180, 0); // Face downward
        }
        else if (spawnSide == 1) // Right
        {
            spawnPosition = new Vector3(spawnRangeX + sideSpawnOffset, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            spawnRotation = Quaternion.Euler(0, 270, 0); // Face left
        }
        else if (spawnSide == 2) // Left
        {
            spawnPosition = new Vector3(-spawnRangeX - sideSpawnOffset, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            spawnRotation = Quaternion.Euler(0, 90, 0); // Face right
        }

        // Generate a random index for the animal prefab
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Instantiate the selected animal prefab at the random spawn position with the correct rotation
        Instantiate(animalPrefabs[animalIndex], spawnPosition, spawnRotation);
    }
}


