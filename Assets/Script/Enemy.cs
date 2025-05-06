using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 velocity;
    [SerializeField] Transform[] movePoints;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Behavior();
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    private void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        velocity *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
