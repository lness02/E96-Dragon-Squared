using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public int maxHealth = 100;
    private int currentHealth; 

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
        Debug.Log("enemy died");

        // animate

        // disable the enemy
        GetComponent<Collider2D>().enabled = false; 
        this.enabled = false; 
        enemy.SetActive(false);
    }
}
