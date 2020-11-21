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
    private bool _isJumping = false;
    [SerializeField] private GameObject gameObjectArrow;
    [SerializeField] private Transform _transform;
    [SerializeField] private float force;
    [SerializeField] private bool isReload;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

  
    void FixedUpdate()
    {
        _animator.SetBool("isGrounded", _graundDetection._isGraund);
        if(!_isJumping && !_graundDetection._isGraund)
        {
            _animator.SetTrigger("StartFal");
        }

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
            _isJumping = true;
        }

       
        _animator.SetFloat("Speed",Mathf.Abs( direction.x));
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isReload == true)
        {
            _animator.SetTrigger("Archery");
        }
    }

    void CheckShoot()
    { 
        GameObject prefab = Instantiate(gameObjectArrow, _transform.position, Quaternion.identity);
        prefab.GetComponent<Arrow>().SetImpuls(Vector2.right, _spriteRenderer.flipX ? -force * 5 : force * 5);
        isReload = false;
        StartCoroutine(ReloadArow());
    }

    private IEnumerator ReloadArow()
    {
        yield return new WaitForSeconds(3f);
            isReload = true;
        yield break;
    }
}
