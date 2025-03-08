using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonhMovement : MonoBehaviour
{
    [Header("Configuraciones de Movimiento")]
    public float JumpForce = 4f;
    public float Speed = 1f;

    [Header("Configuraciones de Disparo")]
    public GameObject BulletPrefab;
    public Transform FirePoint; // Nuevo objeto en Unity que indica dónde dispara

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

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

        // Detección de suelo con BoxCollider en lugar de Raycast
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
        Vector2 direction = (transform.localScale.x == 1.0f) ? Vector2.right : Vector2.left;

        // Instanciar la bala en el punto de disparo (FirePoint)
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * Speed, Rigidbody2D.linearVelocity.y);
    }
}
