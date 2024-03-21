using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    [SerializeField] private Transform refPie;

    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento del personaje

    [SerializeField] private float jumpForce = 150;
    [SerializeField] private bool onFloor = false;
    private bool lookAtRight = true;
    private int velocityHash, YVelocityHash,onFloorHash;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        refPie = GameObject.Find("Pie").gameObject.transform;

        velocityHash = Animator.StringToHash("Velocity");
        onFloorHash = Animator.StringToHash("onFloor");
        YVelocityHash = Animator.StringToHash("YVelocity");
    }

    private void Update()
    {
        Move();
        Jump();
        
        // Tells to the animator the Y velocity of the player
        playerAnimator.SetFloat(YVelocityHash, playerRB.velocity.y);
    }

    private void Jump()
    {
        onFloor = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 3);
        playerAnimator.SetBool(onFloorHash, onFloor);
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

        if (moveInput > 0 && !lookAtRight)
        {
            Turn();
        }
        else if (moveInput < 0 && lookAtRight)
        {
            Turn();
        }

        float moveVelocity = moveInput * moveSpeed;

        playerAnimator.SetFloat(velocityHash, Math.Abs(moveInput));

        // Aplicar la velocidad al Rigidbody2D del personaje
        playerRB.velocity = new Vector2(moveVelocity, playerRB.velocity.y);
    }

    // Change the direction the player is facing
    private void Turn()
    {
        lookAtRight = !lookAtRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void Attack()
    {
    }
}