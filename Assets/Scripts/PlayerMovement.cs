using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _minimalHeight;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;
    private Rigidbody2D _rBody;
    private bool _isGrounded;

    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _isGrounded = true;
    }

    
    private void Update()
    {
        _animator.SetBool("IsGrounded", _isGrounded);
        float direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            Move(direction);
            _sprite.flipX = (direction < 0);
        }

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

        UpdateAnimator();
        CheckFall();
    }

    private void Flip(float direction)
    {
        Vector3 scale = transform.localScale;
        scale.x = (direction < 0) ? 1 : -1;
        transform.localScale = scale;
    }

    private void UpdateAnimator()
    {
        
         _animator.SetBool("IsJumping", !_isGrounded);
        _animator.SetFloat("Speed", Mathf.Abs(_rBody.velocity.x));
    }

    private void Move(float direction)
    {
        Vector2 playerVelocity = _rBody.velocity;
        playerVelocity.x = direction * _speed;
        _rBody.velocity = playerVelocity;
    }

    private void Jump()
    {
        _rBody.AddForce(Vector2.up * _jumpForce);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGrounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGrounded = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ResetPlayerPosition();
        }
    }

    private void CheckFall()
    {
        if (transform.position.y < _minimalHeight)
        {
            ResetPlayerPosition();
        }
    }

    private void ResetPlayerPosition()
    {
        _rBody.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
}
