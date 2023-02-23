using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public float doubleJumpForce;
    public float wallJumpForce;
    public float wallSlideSpeed;
    public float wallStickTime;
    public float wallJumpTime;
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;
    public float gravityScale;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Transform groundCheck;
    public Transform wallCheck;

    private Rigidbody2D rb;
    private Collider2D col;
    private Animator anim;
    private bool facingRight = true;
    private bool isGrounded = false;
    private bool isWallSliding = false;
    private bool isDashing = false;
    private bool isWallJumping = false;
    private bool canDoubleJump = false;
    private float wallJumpDirection;
    private float lastDashTime;
    private float wallStickStartTime;
    private float wallJumpStartTime;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Check if player is wall sliding
        isWallSliding = Physics2D.OverlapCircle(wallCheck.position, 0.1f, wallLayer) && !isGrounded && rb.velocity.y < 0;

        // Handle movement
        float moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Flip player sprite if necessary
        if ((moveDirection > 0 && !facingRight) || (moveDirection < 0 && facingRight)) {
            Flip();
        }

        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canDoubleJump = true;
            }
            else if (isWallSliding) {
                wallJumpDirection = facingRight ? -1 : 1;
                rb.velocity = new Vector2(wallJumpForce * wallJumpDirection, doubleJumpForce);
                isWallJumping = true;
                wallJumpStartTime = Time.time;
            }
            else if (canDoubleJump) {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                canDoubleJump = false;
            }
        }

        // Handle wall sliding
        if (isWallSliding) {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
            if (Time.time >= wallStickStartTime + wallStickTime) {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                wallJumpDirection = facingRight ? -1 : 1;
                rb.velocity = new Vector2(wallJumpForce * wallJumpDirection, doubleJumpForce);
                isWallJumping = true;
                wallJumpStartTime = Time.time;
            }
        }

        // Handle wall jumping
        if (isWallJumping) {
            if (Time.time >= wallJumpStartTime + wallJumpTime) {
                isWallJumping = false;
            }
        }
    // Handle dashing
    if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown) {
        anim.SetTrigger("Dash");
        isDashing = true;
        lastDashTime = Time.time;
        if (facingRight) {
            rb.velocity = new Vector2(dashForce, 0f);
        }
        else {
            rb.velocity = new Vector2(-dashForce, 0f);
        }
        StartCoroutine(DashTimer());
    }

    // Apply gravity
    rb.velocity += gravityScale * Physics2D.gravity * Time.deltaTime;

    // Update animator
    anim.SetBool("Grounded", isGrounded);
    anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    anim.SetFloat("VerticalSpeed", rb.velocity.y);
}

IEnumerator DashTimer() {
    yield return new WaitForSeconds(dashDuration);
    isDashing = false;
}

void Flip() {
    facingRight = !facingRight;
    transform.Rotate(0f, 180f, 0f);
}
