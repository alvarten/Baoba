using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vecGravity;
    private bool isJumping;
    private float jumpCounter;

    [Header("Jump System")]
    [SerializeField] private int jumpForce = 18;
    [SerializeField] private float fallMultiplier = 5f;
    [SerializeField] private float jumpTime = 0.4f;
    [SerializeField] private float jumpMultiplier = 3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")))
        {
            Jump();
            isJumping = true;
            jumpCounter = 0;
        }

        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime)
            {
                isJumping = false;
            }
            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = (1 - t) * jumpMultiplier;
            }
            rb.velocity += currentJumpM * Time.deltaTime * vecGravity;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            isJumping = false;
            jumpCounter = 0f;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity -= fallMultiplier * Time.deltaTime * vecGravity;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 1f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
