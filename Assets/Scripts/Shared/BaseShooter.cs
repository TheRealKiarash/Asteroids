using UnityEngine;

public abstract class BaseShooter : MonoBehaviour
{
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float fireRate = 0.1f;

    private float nextFireTime = 0.0f;

    protected void TryFire()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }

    protected abstract void Fire();
}
