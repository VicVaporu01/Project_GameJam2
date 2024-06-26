using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Animator playerAnimator;
    private AudioSource gunAS;

    [SerializeField] private AudioClip laserSound;

    private int isWeaponRaisedHash;
    public float bulletSpeed = 25.0f;
    private float weaponRaisedTime = 3.0f;

    private void Start()
    {
        playerAnimator = GetComponentInParent<Animator>();
        gunAS = GetComponent<AudioSource>();
        isWeaponRaisedHash = Animator.StringToHash("isWeaponRaised");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        // Calcula la posición de inicio de la bala como la posición actual del jugador
        Vector3 bulletStartPosition = transform.position;

        // Instancia la bala en la posición calculada con la rotación del jugador
        GameObject bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = bulletStartPosition;
        bullet.transform.rotation = transform.rotation;

        gunAS.PlayOneShot(laserSound);

        playerAnimator.SetBool(isWeaponRaisedHash, true);

        BulletMovement(bullet);

        StartCoroutine(LowerWeaponAfterDelay());
    }

    private void BulletMovement(GameObject bullet)
    {
        // Accede al componente Rigidbody de la bala y le aplica una velocidad en la dirección hacia adelante del jugador
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = transform.right * bulletSpeed;
    }

    private IEnumerator LowerWeaponAfterDelay()
    {
        yield return new WaitForSeconds(weaponRaisedTime);

        playerAnimator.SetBool(isWeaponRaisedHash, false);
    }
}