using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBulletPrefab;

    public bool canShoot = false;
    private float shootTimer = 1.0f;
    public float enemyBulletSpeed = 25.0f;

    private void Start()
    {
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (canShoot && shootTimer <= 0.0f)
        {
            canShoot = false;
            StartCoroutine(ShootController());
            shootTimer = 1.0f;
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
    }
}