using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 100f;
    public float shootRate = 0.5f;
    public float shootRateTime = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shootRateTime){
                GameObject newBullet;
                // Calcula la posición de inicio de la bala como la posición actual del jugador
                Vector3 bulletStartPosition = transform.position;
                // Instancia la bala en la posición calculada con la rotación del jugador
                newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                // Accede al componente Rigidbody de la bala y le aplica una velocidad en la dirección hacia adelante del jugador
                newBullet.GetComponent<Rigidbody2D>().AddForce(spawnPoint.right * bulletSpeed);
                shootRateTime = Time.time + shootRate;
                Destroy(newBullet,3);
            }
        }
    }
}
