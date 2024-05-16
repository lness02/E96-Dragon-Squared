using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    [SerializeField] public float attackRange = 0.5f;
    [SerializeField] public int attackDamage = 20; 
    [SerializeField] public float attackRate = 2f;
    float nextAttackTime = 0f; 

    void OnFire() {
        if (Time.time >= nextAttackTime) {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack() {
        animator.SetTrigger("Attack");

        // detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage them
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }
}
