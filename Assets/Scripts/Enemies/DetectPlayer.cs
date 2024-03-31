using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyController;

    [SerializeField] private bool canAttack = false;

    private void Start()
    {
        _enemyController = GetComponentInParent<EnemyController>();
    }

    private void FixedUpdate()
    {
        // To see the raycast in the scene view
        // Ray2D ray = new Ray2D(transform.position, transform.right);
        // Debug.DrawRay(ray.origin, ray.direction * 10.0f);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            canAttack = true;
            _enemyController.AttackPlayer(canAttack);
        }
        else
        {
            canAttack = false;
            _enemyController.AttackPlayer(canAttack);
        }
    }
}