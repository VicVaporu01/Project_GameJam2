using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDinoController : MonoBehaviour
{
    public float radius = 5.0f;
    public float speed;
    private bool alert;
    private bool isWalking = false;
    public LayerMask playerLayer;
    public Transform player;  
    private Vector2 targetPosition;
    private Animator DinoAnim;
       
    [SerializeField] private float health = 5.0f;



    private void Start()
    {
        DinoAnim = GetComponent<Animator>();
        StartCoroutine(UpdatePlayerDetection());
    }

    private void Update()
    {
        if (alert)
        {
            MoveTowardsPlayer();
        }
        
        else
        {
            // Si no está alerta, desactiva la animación de caminar
            isWalking = false;
            DinoAnim.SetBool("walk", false);
        }

        if (health <= 0)
        {
            DinoAnim.SetBool("burstDino", true); 
            Destroy(gameObject, DinoAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length);       
                               
        }
    }
    // Interfaz que actualiza la deteccion del jugador
    private IEnumerator UpdatePlayerDetection()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f); // Intervalo de actualización
        while (true)
        {
            alert = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
            yield return wait;
        }
    }
    
    // El enemigo sigue al jugador
    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            targetPosition = player.position;
            Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            transform.Translate(moveDirection * speed * Time.deltaTime); 
            DinoAnim.SetBool("walk", true);           
        }
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(other.gameObject.GetComponent<BulletController>().GetDamage());
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;                  
    }

    // Crea un gizmo visual para ver el radio de ataque
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
