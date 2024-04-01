using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DestroyEnemy : MonoBehaviour
{

    private Animator DinoAnim;
    
    private void Start()
    {
        DinoAnim = GetComponent<Animator>();        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que se colisiona tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruye el jugador
            DinoAnim.SetTrigger("attack_trig");
            Destroy(collision.gameObject);

            // Desactiva la animación después de un tiempo
            StartCoroutine(DisableAnimationAfterDelay());
          
        }

        // Método para desactivar la animación 
        IEnumerator DisableAnimationAfterDelay()
        {
        // Espera un medio segundo antes de desactivar la animación
        yield return new WaitForSeconds(0.5f);
        
        // Desactiva la animación
        DinoAnim.enabled = false;
        
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
