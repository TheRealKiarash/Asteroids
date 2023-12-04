using UnityEngine;

public class LargeAsteroid : BaseAsteroid
{
    [SerializeField] protected MediumAsteroid mediumAsteroidPrefab;

    protected override void HandleDestruction()
    {
        SpawnSmallerAsteroids(asteroidsToBreakInto, mediumAsteroidPrefab);
        base.HandleDestruction();
    }

    private void SpawnSmallerAsteroids(int count, MediumAsteroid prefab)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
