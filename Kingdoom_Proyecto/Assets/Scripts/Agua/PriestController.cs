using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PriestController : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    public float jumpPower = 5f;
    private bool isFacingRight = true;
    bool isGround = true;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("yVelocity", rb.velocity.y);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGround())
        {
            isGround = false;
            animator.SetBool("IsJumping", !isGround);
            Debug.Log(animator.GetBool("IsJumping"));
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        if(Input.GetKey(KeyCode.Tab) && IsGround())
        {
            animator.SetBool("surf",true);
        }
        else
        {
            animator.SetBool("surf", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && IsGround())
        {
            animator.SetTrigger("Roll");
        }

        if(Input.GetKeyDown(KeyCode.H) && IsGround())
        {
            animator.SetTrigger("Heal");
        }

        Flip();

    }

    private void FixedUpdate()
    {
        GroundCheck();
        if (!animator.GetBool("surf"))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed * 2, rb.velocity.y);
        }
            
        animator.SetFloat("Speed", Math.Abs(rb.velocity.x));
    }

    void GroundCheck()
    {
        isGround = false;

        if (IsGround())
        {
            isGround = true;
        }

        animator.SetBool("IsJumping", !isGround);

    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
       animator.SetBool("IsJumping", !isGround);
    }
}
