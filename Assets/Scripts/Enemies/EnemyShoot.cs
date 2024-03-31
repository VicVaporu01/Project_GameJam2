using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private AudioSource enemyAudioSource;

    [SerializeField] private AudioClip enemyShootClip;
    public bool canShoot = false;
    private float shootTimer = 1.5f;
    public float enemyBulletSpeed = 25.0f;

    private void Start()
    {
        enemyAudioSource = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        if (shootTimer > 0.0f)
        {
            shootTimer -= Time.deltaTime;
        }
        else if (canShoot && shootTimer <= 0.0f)
        {
            Shoot();
        }
    }

    private IEnumerator ShootController()
    {
        yield return new WaitForSeconds(1.0f);
        Shoot();
    }

    private void Shoot()
    {
        GameObject enemyBullet = EnemyBulletPool.Instance.RequestBullet();
        enemyBullet.transform.position = transform.position;
        enemyBullet.transform.rotation = transform.rotation;

        Rigidbody2D enemyBulletRB = enemyBullet.GetComponent<Rigidbody2D>();
        enemyBulletRB.velocity = transform.right * enemyBulletSpeed;
        enemyAudioSource.PlayOneShot(enemyShootClip);
        ResetTimer();
    }

    private void ResetTimer()
    {
        shootTimer = 1.5f;
    }
}