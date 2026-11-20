using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _kickLeft;
    [SerializeField] private GameObject _kickRight;
    [SerializeField] private GameController _gameController;
    // Add member variables to store references to this GameObject's 
    //      Rigidbody, Animator, and SpriteRenderer.
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private float _attackCooldown;

    private bool _facingLeft;
    private bool _isGrounded = true;
    private float _attackTime;
    private static readonly int WalkingHash = Animator.StringToHash("walking");
    private static readonly int AttackHash = Animator.StringToHash("attack");
    private static readonly int OnGroundHash = Animator.StringToHash("onGround");

    // ------------------------------------------------------------------------
    // Add a built-in UNITY METHOD that runs EVERY FRAME.
        // Detect input to move player left/right, jump, and kick
        // Change character facing with SpriteRenderer.flipX value
        // Set animation parameters 

    // ------------------------------------------------------------------------
    private void FixedUpdate()
    {
        var horDir = Input.GetAxis("Horizontal");
        rb.linearVelocityX = horDir * _speed * Time.deltaTime;
        if (horDir != 0.0)
        {
            animator.SetBool(WalkingHash, true);
            _facingLeft = horDir < 0; 
            spriteRenderer.flipX = _facingLeft;
        }
        else
        {
            animator.SetBool(WalkingHash, false);
        }

        if (Input.GetButton("Jump") && _isGrounded)
        {
            _isGrounded = false;
            rb.linearVelocityY = _jump;
        }
        animator.SetBool(OnGroundHash, _isGrounded);

        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0f && Input.GetButton("Kick"))
        {
            Kick();
        }
    }

    private void Kick()
    {
        _attackTime = _attackCooldown;
        // Set animation parameter.
        animator.SetTrigger(AttackHash);
        // Either activate left or right kick based on character facing

        if (_facingLeft)
        {
            _kickLeft.SetActive(true);
        }
        else
        {
            _kickRight.SetActive(true);
        }
    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity method to detect COLLISION.
    // Use this to avoid allowing the Player to double jump- they should
    //      collide with an object with the Ground tag before being able to
    //      jump again.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionTag = collision.gameObject.tag;
        if (!collisionTag.Equals("Ground") && !collisionTag.Equals("Platform"))
            return;
        _isGrounded = true;
    }
}
