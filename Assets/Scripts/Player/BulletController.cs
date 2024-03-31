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
    [SerializeField] private float lifeTime = 2.0f;

    private void Start()
    {
        bulletAnimator = GetComponent<Animator>();
        hitHash = Animator.StringToHash("hit");
        bulletRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(LifeTimeWatcher());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Crate") ||
            other.gameObject.CompareTag("Player"))
        {
            bulletAnimator.SetTrigger(hitHash);
            bulletRB.velocity = Vector2.zero;
        }
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator LifeTimeWatcher()
    {
        yield return new WaitForSeconds(lifeTime);

        Desactivate();
    }

    public float GetDamage()
    {
        return damage;
    }
}