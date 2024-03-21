using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Animator playerAnimator;

    private int isWeaponRaisedHash;
    public float bulletSpeed = 100f;
    private float weaponRaisedTime = 3.0f;

    private void Start()
    {
        playerAnimator = GetComponentInParent<Animator>();
        isWeaponRaisedHash = Animator.StringToHash("isWeaponRaised");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Calcula la posición de inicio de la bala como la posición actual del jugador
            Vector3 bulletStartPosition = transform.position;

            // Instancia la bala en la posición calculada con la rotación del jugador
            GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition, transform.rotation);
            playerAnimator.SetBool(isWeaponRaisedHash, true);

            // Accede al componente Rigidbody de la bala y le aplica una velocidad en la dirección hacia adelante del jugador
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = transform.right * bulletSpeed;

            StartCoroutine(LowerWeaponAfterDelay());
        }
    }

    private IEnumerator LowerWeaponAfterDelay()
    {
        yield return new WaitForSeconds(weaponRaisedTime);

        playerAnimator.SetBool(isWeaponRaisedHash, false);
    }
}