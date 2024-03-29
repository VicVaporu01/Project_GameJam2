using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyShoot _enemyShoot;
    private Animator enemyAnimator;
    private Rigidbody2D enemyRB;

    [SerializeField] private float health = 5.0f;
    private float movementSpeed = 3.0f;

    private bool playerDetected = false;
    private bool lookAtRight = true;
    private bool canTurn = true;
    private float turnTimer = 2.0f;

    private void Start()
    {
        _enemyShoot = GetComponentInChildren<EnemyShoot>();
        enemyAnimator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (!playerDetected)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        if (lookAtRight)
        {
            enemyRB.velocity = new Vector2(movementSpeed, enemyRB.velocity.y);
        }
        else if (!lookAtRight)
        {
            enemyRB.velocity = new Vector2(-movementSpeed, enemyRB.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate") && canTurn)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);
            canTurn = false;
            StartCoroutine(TurnController());
            enemyRB.velocity = Vector2.zero;
            lookAtRight = !lookAtRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= other.gameObject.GetComponent<BulletController>().GetDamage();
        }
    }


    private IEnumerator TurnController()
    {
        yield return new WaitForSeconds(turnTimer);
        canTurn = true;
    }

    public void AttackPlayer(bool canAttack)
    {
        _enemyShoot.canShoot = canAttack;
        playerDetected = canAttack;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}