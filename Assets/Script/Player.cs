using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedRun = 0;
    [SerializeField] private float _speedJump = 0;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Vector3 direction;
    public GraundDetection _graundDetection;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        _animator.SetBool("isGrounded", _graundDetection._isGraund);
        direction = Vector3.zero;
        
       

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
            
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }

        direction *= _speedRun;
        direction.y = _rigidbody.velocity.y;
        _rigidbody.velocity = direction;

        if (direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
            
        if (Input.GetKeyDown(KeyCode.Space) && _graundDetection._isGraund)
        {
            _rigidbody.AddForce(Vector2.up * _speedJump, ForceMode2D.Impulse);
            _animator.SetTrigger("TriggerJump");       
        }

       
        _animator.SetFloat("Speed",Mathf.Abs( direction.x));
    }
}
