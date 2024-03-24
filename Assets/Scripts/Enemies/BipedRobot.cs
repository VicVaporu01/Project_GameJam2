using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BipedRobot : MonoBehaviour
{
    public float speed = 1f;
    public float patrolRange = 3f;
    private Vector3 startPosition;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private bool movingRight = true;
    private bool idle = true;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        startPosition = transform.position;
    }

    void Update()
    {
        if (idle)
        {
            Idle();
        }

    }

    void Idle()
    {
        Debug.Log("Active");
        // Determina la dirección de patrulla del enemigo
        Vector3 patrolDirection = movingRight ? Vector3.right : Vector3.left;

        // Calcula la nueva posición del enemigo basado en su dirección de patrulla y velocidad
        Vector3 newPosition = transform.position + patrolDirection * speed * Time.deltaTime;

        // Si el enemigo se aleja demasiado de su posición inicial o del rango de patrulla, cambia de dirección
        if (Vector3.Distance(startPosition, newPosition) > patrolRange)
        {
            movingRight = !movingRight;
        }

        // Aplica el movimiento al enemigo
        enemyRb.velocity = patrolDirection * speed;
    }

    void Attack()
    {
        // Realizar acciones de ataque aquí
        Debug.Log("Attacking!");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            idle = false;
            Attack();
        }
        idle = true;
    }

    private void Turn()
    {
        movingRight = !movingRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
          
}
