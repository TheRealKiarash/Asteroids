using UnityEngine;

public class Saucer : MonoBehaviour
{
    [SerializeField] private int scoreValue = 500;
    [SerializeField] private float speed = 1.0f;

    private Rigidbody2D rb;

    void Start()
    {
        InitializeMovement();
    }

    void InitializeMovement()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            HandleDestruction();
        }
    }

    private void HandleDestruction()
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
