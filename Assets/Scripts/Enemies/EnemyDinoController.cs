using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDinoController : MonoBehaviour
{
    public float radius = 5.0f;
    public float speed;
    private bool alert;
    public LayerMask playerLayer;
    public Transform player;  
    private Vector2 targetPosition;

    private void Start()
    {
        StartCoroutine(UpdatePlayerDetection());
    }

    private void Update()
    {
        if (alert)
        {
            MoveTowardsPlayer();
        }
    }
    // Interfaz que actualiza la deteccion del jugador
    private IEnumerator UpdatePlayerDetection()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f); // Intervalo de actualización
        while (true)
        {
            alert = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
            yield return wait;
        }
    }
    
    // El enemigo sigue al jugador
    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            targetPosition = player.position;
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            transform.Translate(moveDirection * speed * Time.deltaTime);            
        }
    }
    // Crea un gizmo visual para ver el radio de ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
