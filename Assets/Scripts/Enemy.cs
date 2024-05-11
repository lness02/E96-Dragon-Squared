using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = 3f; 
    [SerializeField] private float attackDamage = 10f; 
    [SerializeField] private float attackSpeed = 1f;
    public GameObject enemy;
    private float canAttack; 
    private Transform target;
    public int maxHealth = 100;
    private int currentHealth; 

    void Start() {
        currentHealth = maxHealth;
    }

    private void FixedUpdate() {
        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
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

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die(); 
        }
    }

    void Die() {
        Debug.Log("enemy died");

        // animate

        // disable the enemy
        GetComponent<Collider2D>().enabled = false; 
        this.enabled = false; 
        enemy.SetActive(false);
    }
}
