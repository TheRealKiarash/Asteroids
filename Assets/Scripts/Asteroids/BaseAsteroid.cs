using UnityEngine;

public class BaseAsteroid : MonoBehaviour
{
    [SerializeField] protected int scoreValue = 100;
    [SerializeField] protected int asteroidsToBreakInto = 2;
    [SerializeField] protected float speed = 1.0f;
    [SerializeField] protected float size = 1.0f;

    protected Rigidbody2D rb;

    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        //Initializes Direction, Velocity, Rotation, and Scale: 
        rb = GetComponent<Rigidbody2D>();
        Vector2 movementDirection = Random.insideUnitCircle.normalized;
        rb.velocity = movementDirection * speed;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.localScale = Vector3.one * size;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            HandleDestruction();
        }
    }

    protected virtual void HandleDestruction()
    {
        GameManager.Instance.AddScore(scoreValue);
        Spawner.Instance.AsteroidDestroyed();
        Destroy(gameObject);
    }
}
