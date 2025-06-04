using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1.5f;
    public float minY = -1f;
    public float maxY = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnRate);
    }

    void SpawnPipe()
    {
        float yOffset = Random.Range(minY, maxY);
        Instantiate(pipePrefab, new Vector3(3f, yOffset, 0f), Quaternion.identity);
    }
}
