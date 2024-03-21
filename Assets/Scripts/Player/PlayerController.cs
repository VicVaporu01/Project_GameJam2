using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private Transform refPie;

    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento del personaje

    [SerializeField] private float jumpForce = 150;
    [SerializeField] private bool onFloor = false;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        refPie = GameObject.Find("Pie").gameObject.transform;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        onFloor = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 3);
        if (Input.GetButtonDown("Jump") && onFloor)
        {
            playerRB.AddForce(
                new Vector2(0, jumpForce),
                ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        float moveVelocity = moveInput * moveSpeed;

        // Aplicar la velocidad al Rigidbody2D del personaje
        playerRB.velocity = new Vector2(moveVelocity, playerRB.velocity.y);
    }

    private void Attack()
    {
        
    }
}