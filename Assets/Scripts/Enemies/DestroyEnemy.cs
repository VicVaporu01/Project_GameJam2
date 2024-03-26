using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
   // Método que se llama cuando el colisionador entra en contacto con otro colisionador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que se colisiona tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruye el objeto con el que se colisionó (en este caso, el jugador)
            Destroy(collision.gameObject);
        }

         // Verifica si el objeto con el que se colisiona tiene la etiqueta "PlayerBullet"
       if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            // Destruye este objeto (enemigo) cuando es golpeado por un PlayerBullet
            Debug.Log("Prueba Colision");
            Destroy(gameObject);
        }
    }
}
