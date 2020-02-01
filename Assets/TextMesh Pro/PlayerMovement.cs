using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _Speed = 10.0f;
    [SerializeField]
    float _JumpPower = 2.0f;

    [SerializeField]
    float _MaxJump = 3.0f;

    float jumpThreshold = 0;

    public bool isJumping = false;
    public bool isFalling = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    Animator myAnimation;

    bool isFacingRight = false;

    Rigidbody2D rigBody;

    Collider2D playerCollider;

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        if (!rigBody)
        {
            Debug.LogWarning("Missing rigid body on player");
        }

        jumpThreshold = _MaxJump + gameObject.transform.position.y;
    }

    public void MovePlayer (Vector2 direction)
    {
        Vector2 newForce = direction * _Speed;
        rigBody.velocity = newForce;

        myAnimation.SetFloat("speed", rigBody.velocity.magnitude);
        if (direction.x > 0 && isFacingRight)
        {
            FlipCharacter();
        }
        else if (direction.x < 0 && !isFacingRight)
        {
            FlipCharacter();
        }
    }

    public void JumpPlayer()
    {
        if (isGrounded)
        {
            Debug.Log("fuck");
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isJumping)
        {
            Vector2 jumpForce = new Vector2(rigBody.velocity.x, 1) * _JumpPower;
            rigBody.AddForce(jumpForce, ForceMode2D.Impulse);
        }

        if (transform.position.y >= jumpThreshold)
        {
            isJumping = false;
        }
    }
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight; 
        Vector3 scaler = transform.localScale;

        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
