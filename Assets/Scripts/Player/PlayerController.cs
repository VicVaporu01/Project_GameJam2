using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = System.Numerics.Vector3;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private Transform refPie;
    private AudioSource playerAS;

    [Header("PLAYER STATS")] 
    public float health = 5.0f;

    private float moveInput;
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento del personaje
    [SerializeField] private float jumpForce = 150;

    [Header("SOUNDS")] 
    [SerializeField] private AudioClip stepOnRock;
    [SerializeField] private AudioClip jump;
    [SerializeField] private float stepInterval = 0.5f;

    private float stepTimer;

    private bool onFloor = false;
    private bool lookAtRight = true;
    private int velocityHash, YVelocityHash, onFloorHash;

    private void Start()
    {
        Time.timeScale = 1;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAS = GetComponent<AudioSource>();
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

        // Actualiza el temporizador de los pasos
        if (stepTimer > 0)
        {
            stepTimer -= Time.deltaTime;
        }
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
            playerAS.PlayOneShot(jump);
        }
    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Check the direction the player is facing
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

        // Apply the velocity to the rigidbody of the player
        playerRB.velocity = new Vector2(moveVelocity, playerRB.velocity.y);

        // Reproduce the steps sound if the player is moving and is on the floor
        if (onFloor && moveInput != 0 && stepTimer <= 0)
        {
            // Play the step sound and then reset the timer
            playerAS.PlayOneShot(stepOnRock);
            stepTimer = stepInterval; 
        }
    }

    // Change the direction the player is facing
    private void Turn()
    {
        lookAtRight = !lookAtRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*
            Variable para pruebas solamente, cuando usen el método tienen
            que tener un parametro que será una caracteristica del controlador de
             balas del enemigo con el daño que hace la bala
        */
        float enemyBulletDamage = 1.0f;
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //TakeDamage(other.gameObject.GetComponent<EnemyBulletController>().bulletDamage);
            TakeDamage(enemyBulletDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}