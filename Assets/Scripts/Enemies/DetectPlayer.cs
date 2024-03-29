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

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = true;
            _enemyController.AttackPlayer(canAttack);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canAttack = false;
            _enemyController.AttackPlayer(canAttack);
        }
    }
}