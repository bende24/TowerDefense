using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Movement
    [Range(1,10)]
    public float moveSpeed;
    [Range(1,10)]
    public float jumpVelocity;
    private float horizontalMovement = 0f;
    private float jumpPressed = 0f;
    [Range(0,1)]
    public float jumpPressedTime;
    private float groundedRemember = 0f;
    [Range(0,1)]
    public float coyoteTimer;
    [Range(0,1)]
    public float cutJumpHeight;
    private bool isGrounded;
    private bool isOnPlatform;

    public Rigidbody2D rigidbody2d;
    public CapsuleCollider2D collider2d;
    public Animator animator;
    public Transform bowPos;

    void Update() {
        if(!PauseMenu.Instance.isGamePaused) {
            move();
            animate();
        }
    }

    /// <summary>
    /// This function is responsible for moving the player
    /// </summary>
    private void move() {
        // Vertical movement
        groundedRemember -= Time.deltaTime;
        if(isGrounded) {
            groundedRemember = coyoteTimer;
        }

        jumpPressed -= Time.deltaTime;
        if (Input.GetButtonDown("Jump") ) {
            jumpPressed = jumpPressedTime;
        }

        if(Input.GetButtonUp("Jump") && rigidbody2d.velocity.y > 0) {
            rigidbody2d.velocity = Vector2.up * rigidbody2d.velocity.y * cutJumpHeight;
        }

        if(jumpPressed > 0 && groundedRemember > 0) {
            AudioManager.Instance.Play("Jump");
            jumpPressed = 0;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        // Horizontal movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        rigidbody2d.velocity = new Vector2(horizontalMovement * moveSpeed, rigidbody2d.velocity.y);
        if(rigidbody2d.velocity.x != 0 && isGrounded) {
            AudioManager.Instance.Play("Run");
        }

        // Falling under platfrom not working as intended :(
            
        // if(isOnPlatform && Input.GetAxisRaw("Vertical") < 0) {
        //     transform.Translate(new Vector2(0, -0.24f), transform);
        // }
    }

    /// <summary>
    /// This function is responsible for animating the player
    /// </summary>
    void animate() {
        // Movement animations
        animator.SetFloat("SpeedY", rigidbody2d.velocity.y);
        animator.SetFloat("SpeedX", Mathf.Abs(horizontalMovement));
        animator.SetBool("isGrounded", isGrounded);

        // Flip player sprite
        Vector3 characterScale = transform.localScale;
        if (horizontalMovement != 0) {
            characterScale.x = horizontalMovement;
        }
        transform.localScale = characterScale;
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Base") ||
            collision.collider.CompareTag("Platform")) {
            isGrounded = false;
        }
        if(collision.collider.CompareTag("Platform")) {
            isOnPlatform = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Base") ||
            collision.collider.CompareTag("Platform")) {
            isGrounded = true;
        }
        if(collision.collider.CompareTag("Platform")) {
            isOnPlatform = true;
        }
    }
}