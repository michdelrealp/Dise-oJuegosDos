using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;

    void Update()
    {
        if (John != null) // Mientras John exista, sigue su posici�n
        {
            Vector3 position = transform.position;
            position.x = John.transform.position.x;
            transform.position = position;
        }
    }
}

