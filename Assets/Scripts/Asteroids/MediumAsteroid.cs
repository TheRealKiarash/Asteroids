using UnityEngine;

public class MediumAsteroid : BaseAsteroid
{
    [SerializeField] protected SmallAsteroid smallAsteroidPrefab;

    protected override void HandleDestruction()
    {
        SpawnSmallerAsteroids(asteroidsToBreakInto, smallAsteroidPrefab);
        base.HandleDestruction();
    }

    private void SpawnSmallerAsteroids(int count, SmallAsteroid prefab)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
