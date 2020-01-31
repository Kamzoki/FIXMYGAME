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

    bool isJumping = false;
    bool canJump = true;

    Rigidbody2D rigBody;

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        
        if (!rigBody)
        {
            Debug.LogWarning("Missing rigid body on player");
        }
    }

    public void MovePlayer (Vector2 direction)
    {
            Vector2 newForce = direction * _Speed;
            rigBody.velocity = newForce;
    }

    public void JumpPlayer()
    {
        if (!isJumping && canJump)
        {
            canJump = false;
            isJumping = true;

            Vector2 jumpForce = new Vector2(0, 1) * _JumpPower;

            float jumpThreshold = _MaxJump + gameObject.transform.position.y;
            if (gameObject.transform.position.y <= jumpThreshold)
            {

                rigBody.velocity = jumpForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("LandScape"))
        {
            canJump = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("LandScape"))
        {
            canJump = false;
            isJumping = true;
        }
    }
}
