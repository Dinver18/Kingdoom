using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D),typeof(TouchingDirection))]

public class PlayerControl : MonoBehaviour
{
    public float runSpeed = 8f;
    TouchingDirection touchingDirection;

    public float CurrentMoveSpeed
    {
        get
        {
            if (IsRunning)
            {
                return runSpeed;
            }
            return 0;
        }
    }

    Vector2 moveInput;

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationString.isRunning, _isRunning);
        }
    }

    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;


        }
    }

    public float JumImpulse = 10f;

    public bool _isFacingRight = true;

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirection = GetComponent<TouchingDirection>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        animator.SetFloat(AnimationString.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>();

        // Verifica si las teclas de arriba o abajo están presionadas
        if (moveInput.y != 0)
        {
            // No hagas nada si se presionan las teclas de arriba o abajo
            return;
        }

        IsRunning = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Check if alive as well
        if (context.started && touchingDirection.IsGrounded)
        {
            animator.SetTrigger(AnimationString.jump);
            rb.velocity = new Vector2(rb.velocity.x, JumImpulse);
        }
      
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //Face the right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //Face the left
            IsFacingRight = false;
        }
    }
}
