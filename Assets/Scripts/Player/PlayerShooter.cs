using UnityEngine;

public class PlayerShooter : BaseShooter
{
    [SerializeField] private KeyCode shootKey = KeyCode.Space;

    void Update()
    {
        if(Input.GetKey(shootKey))
        {
            TryFire();
        }
    }

    protected override void Fire()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
