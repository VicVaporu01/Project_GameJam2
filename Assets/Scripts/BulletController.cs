using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator bulletAnimator;
    private Rigidbody2D bulletRB;

    private int hitHash;

    private void Start()
    {
        bulletAnimator = GetComponent<Animator>();
        hitHash = Animator.StringToHash("hit");
        bulletRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bulletAnimator.SetTrigger(hitHash);
        bulletRB.velocity = Vector2.zero;
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }
}