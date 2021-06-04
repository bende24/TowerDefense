using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Range(0,10)]
    public float moveSpeed;
    [Range(1,10)]
    public float jumpVelocity;
    private float horizontalMovement = 0f;
    private float groundedRemember = 0f;
    [Range(0,1)]
    public float coyoteTimer;
    public bool isGrounded;
    private float slowPercentage = 1;

    public Rigidbody2D rigidbody2d;
    public Animator animator;
    public EnemySystem enemySystem;
    public Collider2D collider2d;

    void Awake() {
        moveSpeed = enemySystem.enemy.movespeed;
    }

    void Update() {
        move();
        animate();
    }

    /// <summary>
    /// This function is responsible for moving the enemy
    /// </summary>
    private void move() {
        // Vertical movement
        groundedRemember -= Time.deltaTime;
        if(isGrounded) {
            groundedRemember = coyoteTimer;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up * collider2d.bounds.size.magnitude, Vector2.up, 0.7f);

        if(!hit) {
            if(!isGrounded && groundedRemember > 0.0f) {
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
            }
        }

        // Horizontal movement
        horizontalMovement = 1f;
        rigidbody2d.velocity = new Vector2(horizontalMovement * moveSpeed * slowPercentage, rigidbody2d.velocity.y);
    }

    /// <summary>
    /// This function is responsible for the enemy animations
    /// </summary>
    void animate() {
        // Movement animations
        animator.SetFloat("SpeedY", rigidbody2d.velocity.y);
        animator.SetFloat("SpeedX", Mathf.Abs(horizontalMovement));
        animator.SetBool("isGrounded", isGrounded);

        Vector3 characterScale = transform.localScale;
        if (horizontalMovement != 0) {
            characterScale.x = horizontalMovement;
        }
        transform.localScale = characterScale;
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform")) {
            isGrounded = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Platform")) {
            isGrounded = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Base")) {
            enemySystem.damage();
        }
    }

    public void getSlowed(float slowPercentage) {
        this.slowPercentage = slowPercentage;
    }
}
