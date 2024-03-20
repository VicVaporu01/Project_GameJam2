using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public Transform refPie;
    
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    public float fuerzaSalto;
    public bool enPiso;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    public void Jump()
    {
        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 3);
        //ani.SetBool("enPiso", enPiso);
        if (Input.GetKeyDown(KeyCode.Space) && enPiso)
        {
            playerRB.AddForce(
                new Vector2(0, fuerzaSalto),
                ForceMode2D.Impulse);
        }
    }

    public void Move()
    {
        // Obtener la entrada horizontal (izquierda/derecha)
        float moveInput = Input.GetAxis("Horizontal");

        // Calcular la velocidad de movimiento
        float moveVelocity = moveInput * moveSpeed;

        // Aplicar la velocidad al Rigidbody2D del personaje
        playerRB.velocity = new Vector2(moveVelocity, playerRB.velocity.y);
    }
}