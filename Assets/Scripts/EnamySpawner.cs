using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f; 
    public Transform[] spawnPoints; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("මචං, Spawn Points ටික Inspector එකට ඇදලා දාන්න අමතක වෙලා!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);

       
        if (spawnPoints[randomIndex] != null)
        {
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}