using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed = 5f;
    public float Lifetime = 3f; // Tiempo antes de que la bala se destruya

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Awake() // Se usa Awake para inicializar antes de Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
        Rigidbody2D.linearVelocity = Direction * Speed;
        Destroy(gameObject, Lifetime); // Destruir la bala después de cierto tiempo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) // Evita que destruya al jugador
        {
            Destroy(gameObject); // Destruir la bala al chocar con algo
        }
    }
}


