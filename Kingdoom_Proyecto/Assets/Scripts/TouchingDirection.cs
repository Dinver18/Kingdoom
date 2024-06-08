using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;

    CapsuleCollider2D touchingCol;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGrounded = true;

    public bool IsGrounded { get {
            return _isGrounded;
        } private set { 
            _isGrounded=value;
            animator.SetBool(AnimationString.isGrounded, _isGrounded);
        } }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down,castFilter,groundHits,groundDistance) > 0;     
    }
}
