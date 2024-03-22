using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Transform playerTransform;

    //public bool activateGravity = false;

    void Start()
    {
        if(rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      // Verifica si la condición para activar la gravedad es verdadera
        if (transform.parent.position.x <= playerTransform.position.x)
        {
            // Activa la gravedad del Rigidbody2D
            rb2d.gravityScale = 1;
        }
        else
        {
            // Desactiva la gravedad del Rigidbody2D
            rb2d.gravityScale = 0;
        }  
    }
}
