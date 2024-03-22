using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Calcula la posición de inicio de la bala como la posición actual del jugador
            Vector3 bulletStartPosition = transform.position;
            
            // Instancia la bala en la posición calculada con la rotación del jugador
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition, transform.rotation);
            
            // Accede al componente Rigidbody de la bala y le aplica una velocidad en la dirección hacia adelante del jugador
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
    }
}