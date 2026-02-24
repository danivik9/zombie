using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRange = 10f;
    public float spawnDelay = 3f;

    void Start()
    {
        InvokeRepeating("SpawnCoin", 1f, spawnDelay);
    }

    void SpawnCoin()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        Vector3 localPos = new Vector3(x, 0, z);
        Vector3 worldPos = transform.TransformPoint(localPos);

        Instantiate(coinPrefab, worldPos, transform.rotation);
    }
}