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

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        startPosition = transform.position;
    }

    void Update()
    {
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


    
}

