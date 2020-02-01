﻿using System.Collections;
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
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    bool isFacingRight = false;

    Rigidbody2D rigBody;

    Collider2D playerCollider;

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
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
            Vector2 jumpForce = new Vector2(0, 1) * _JumpPower;

            if (gameObject.transform.position.y < jumpThreshold)
            {
                Debug.Log(jumpThreshold);
                rigBody.velocity = jumpForce;
            }
            else
            {
                Debug.Log("NotJumping");
                isJumping = false;
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (gameObject.transform.position.y >= jumpThreshold)
        {
            Debug.Log("LOL");
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            JumpPlayer();
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