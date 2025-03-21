using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 5f;
    public float Lifetime = 3f;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction, Collider2D playerCollider)
    {
        Direction = direction.normalized;
        Rigidbody2D.linearVelocity = Direction * Speed; // Aplicar velocidad

        // Ignorar colisiones con el jugador
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);

        Destroy(gameObject, Lifetime); // Destruir la bala tras X segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) // Evitar que la bala destruya al jugador
        {
            Destroy(gameObject);
        }
    }
}

