using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    public float speed = 3f; 
    private float attackDamage = 1f; 
    private float attackSpeed = 1f;
    // public GameObject enemy;
    private float canAttack; 
    private Transform target;
    // public int maxHealth = 100;
    // private int currentHealth; 
    private Rigidbody2D rb;
    private Vector2 direction; 
    private bool isColliding = false;

    void Start() {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate() {
        if (target != null && !isColliding) {
            direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else {
            rb.velocity = Vector2.zero; 
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f; 
            }
            else {
                canAttack += Time.deltaTime; 
            }

            rb.velocity = Vector2.zero;
            isColliding = true; 
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f; 
            }
            else {
                canAttack += Time.deltaTime; 
            }

            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
       if (other.gameObject.tag == "Player") {
            if (attackSpeed <= canAttack) {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f; 
            }
            else {
                canAttack += Time.deltaTime; 
            }

            rb.velocity = Vector2.zero;
            isColliding = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            target = other.transform; 

            Debug.Log("target");
        }
    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            target = null;
        }
    }

    // public void TakeDamage(int damage) {
    //     currentHealth -= damage;

    //     if (currentHealth <= 0) {
    //         Die(); 
    //     }
    // }

    // void Die() {
    //     Debug.Log("enemy died");

    //     // animate

    //     // disable the enemy
    //     GetComponent<Collider2D>().enabled = false; 
    //     this.enabled = false; 
    //     enemy.SetActive(false);
    // }
}
