using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f; // තත්පර 2කට සැරයක්
    public Transform[] spawnPoints; // තැන් කීපයකින් එන්න

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        // Points ටික ලින්ක් කරලා නැත්නම් Error එකක් එන එක නවත්වන්න මේ පේළිය දාන්න
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("මචං, Spawn Points ටික Inspector එකට ඇදලා දාන්න අමතක වෙලා!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);

        // තෝරාගත් Point එක හිස් නැති බව තහවුරු කරගැනීම
        if (spawnPoints[randomIndex] != null)
        {
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}