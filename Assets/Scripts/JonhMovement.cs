using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonhMovement : MonoBehaviour
{
    public float JumpForce = 4f;  // Ajusta el valor según sea necesario
    public float speed = 1f;

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

        Animator.SetBool("running", Horizontal != 0.0f);

        // Dibuja el Raycast en la escena para depuración
        Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.red);

        // Detectar si el personaje está en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);
        Grounded = hit.collider != null;

        // Si se presiona "W" y está en el suelo, salta
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Si está en el suelo, aplicar la fuerza de salto una sola vez
        if (Grounded)
        {
            Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, JumpForce);
        }
    }

    private void FixedUpdate()
    {
        // Movimiento horizontal
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * speed, Rigidbody2D.linearVelocity.y);
    }
}


