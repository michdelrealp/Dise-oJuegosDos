using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{

    [Header("Configuraciones de Disparo")]
    public GameObject BulletPrefab;
    public Transform FirePoint;
  
    public GameObject John;

    private float LastShoot;
    private int Health = 3;

    private void Update()
    {
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); 

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance > 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
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

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }



}
