using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [Header("Asteroid Settings")]
    public GameObject largeAsteroidPrefab;
    public int initialAsteroidCount = 4;
    private const int asteroidSpawnRadius = 5;
    private int AsteroidsToSpawn => initialAsteroidCount + currentLevel - 1;

    [Header("Saucer Settings")]
    public GameObject saucerPrefab;
    public float saucerSpawnInterval = 20.0f;
    public float saucerSpawnDelay = 10.0f; // Delay before first saucer spawn each level
    private const int saucerSpawnRadius = 5;

    private int currentLevel = 0;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    #endregion

    public void StartNewLevel()
    {
        currentLevel++;
        SpawnAsteroids(AsteroidsToSpawn);
        InvokeRepeating(nameof(SpawnSaucer), saucerSpawnDelay, saucerSpawnInterval);
    }

    private void SpawnAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * asteroidSpawnRadius;
        Instantiate(largeAsteroidPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnSaucer()
    {
        Vector2 spawnPosition = Random.insideUnitCircle.normalized * saucerSpawnRadius;
        Instantiate(saucerPrefab, spawnPosition, Quaternion.identity);
    }

    public void AsteroidDestroyed()
    {
        if (FindObjectsOfType<BaseAsteroid>().Length <= 1)
        {
            CancelInvoke(nameof(SpawnSaucer)); // Stop saucer spawning for current level
            StartNewLevel();
        }
    }
}
