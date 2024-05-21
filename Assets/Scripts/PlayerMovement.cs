using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5f; 
    public Rigidbody2D rb;
    public Animator animator; 
    private Vector2 movement; 
    private Vector2 direction; 

    void Awake() {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    void Update() {
        animator.SetFloat("PrevHorizontal", direction.x);
        animator.SetFloat("PrevVertical", direction.y);
    }
    void FixedUpdate() {
        Move(); 
    }

    void OnMove(InputValue input) {
        movement = input.Get<Vector2>(); 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.y < 0) {
            // down
            direction = new Vector2(0, -1);
        }
        else if (movement.y > 0) {
            // up
            direction = new Vector2(0, 1);
        }
        else if (movement.x > 0) {
            // right
            direction = new Vector2(1, 0);
        }
        else if (movement.x < 0) {
            // left
            direction = new Vector2(-1, 0);
        }
    }

    private void Move() {
        rb.velocity = movement * speed; 
    }

    void OnPunch() {
        animator.SetBool("isPunching", true);    
        //animator.SetBool("isPunching", false);    
    }


}
