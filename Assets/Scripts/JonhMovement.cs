using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//comentario para actualizar
public class JonhMovement : MonoBehaviour
{
    [Header("Configuraciones de Movimiento")]
    public float JumpForce = 4f;
    public float Speed = 1f;

    [Header("Configuraciones de Disparo")]
    public GameObject BulletPrefab;
    public Transform FirePoint;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private int Health = 5;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        // Detectar si está en el suelo
        Grounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.2f, 0.15f, LayerMask.GetMask("Ground"));

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Jump()
    {
        if (Grounded)
        {
            Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, JumpForce);
        }
    }

    private void Shoot()
    {
        if (BulletPrefab != null && FirePoint != null)
        {
            Vector2 direction = (transform.localScale.x == 1.0f) ? Vector2.right : Vector2.left;

            // Instanciar la bala
            GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);

            // Pasar el Collider del personaje para ignorar la colisión
            bullet.GetComponent<BulletScript>().SetDirection(direction, GetComponent<Collider2D>());
        }
        else
        {
            Debug.LogError("BulletPrefab o FirePoint no asignados en el Inspector.");
        }
    }


    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * Speed, Rigidbody2D.linearVelocity.y);
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy (gameObject);
    }
}
