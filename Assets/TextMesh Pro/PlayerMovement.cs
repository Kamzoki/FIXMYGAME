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
        float x = direction.x * _Speed;
        float y = rigBody.velocity.y;
        Vector2 newForce = new Vector2(x, y);
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
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isJumping)
        {
            Vector2 jumpForce = transform.up * _JumpPower;
            rigBody.velocity = jumpForce;
            myAnimation.SetTrigger("Jump");
        }

        if (transform.position.y >= jumpThreshold)
        {
            Debug.Log(jumpThreshold);
            isJumping = false;
            Vector2 fallForce = -transform.up * (_JumpPower * 1.2f);
            rigBody.velocity = fallForce;
            myAnimation.SetBool("isFalling", true);
        }

        if (isGrounded)
        { 
            jumpThreshold = _MaxJump + gameObject.transform.position.y;
            myAnimation.SetBool("isFalling", false);
        }
    }
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight; 
        Vector3 scaler = transform.localScale;

        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("DEATH"))
        {
            FindObjectOfType<GameManager>().LoseMenu();
        }
    }
}
