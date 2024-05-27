using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public int maxHealth = 100;
    private int currentHealth; 
    public UnityEvent<GameObject> onDeath = new UnityEvent<GameObject>();

    void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die(); 
        }
    }

    void Die() {
        // Invoke the death event
        onDeath.Invoke(enemy);

        // animate

        // disable the enemy
        GetComponent<Collider2D>().enabled = false; 
        this.enabled = false; 
        enemy.SetActive(false);
    }
}
