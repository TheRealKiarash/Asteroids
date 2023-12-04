using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
   [SerializeField] private KeyCode thrustKey = KeyCode.W;
   [SerializeField] private KeyCode thrustKeyAlternative = KeyCode.UpArrow;

   [SerializeField] private float rotationSpeed = 200.0f;
   [SerializeField] private float thrustForce = 10.0f;

    private Rigidbody2D rb;
    private bool isThrusting = false;
    private float rotationInput = 0.0f;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        if (isThrusting)
        {
            Thrust();
        }
            Rotate();
    }
    private void HandleInput()
    {
        isThrusting = Input.GetKey(thrustKey) || Input.GetKey(thrustKeyAlternative);
        rotationInput = Input.GetAxis("Horizontal");
    }

    private void Rotate()
    {
        rb.angularVelocity = -rotationInput * rotationSpeed;
    }

    private void Thrust()
    {
        rb.AddForce(transform.up * thrustForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.PlayerDestroyed();
            Destroy(gameObject);
        }
    }
}
