using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float lifetime = 1.0f;

    private Rigidbody2D rb;
    void Start()
    {
        SetBulletVelocity();
        Destroy(gameObject, lifetime);
    }

    private void SetBulletVelocity()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
}
