using UnityEngine;

public class SaucerShooter : BaseShooter
{
    [SerializeField] private float maxInaccuracyAngle = 30.0f; // Maximum inaccuracy angle in degrees
    [SerializeField] private int maxAccuracyScore = 40000;

    void Update()
    {
        if (GameManager.Instance.PlayerInstance == null)
            return;

        AdjustAimTowardsPlayer();
        TryFire();
    }

    protected override void Fire()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void AdjustAimTowardsPlayer()
    {
        Vector2 directionToPlayer = (GameManager.Instance.PlayerPosition - transform.position).normalized;
        float inaccuracy = CalculateInaccuracy();
        float inaccuracyAngle = Random.Range(-inaccuracy, inaccuracy);
        Quaternion inaccurateRotation = Quaternion.Euler(0, 0, inaccuracyAngle);
        transform.up = inaccurateRotation * directionToPlayer;
    }

    private float CalculateInaccuracy()
    {
        // Increasing accuracy based on the player's score
        float scoreFactor = Mathf.Clamp01(GameManager.Instance.Score / maxAccuracyScore);
        return maxInaccuracyAngle * (1 - scoreFactor);
    }
}
