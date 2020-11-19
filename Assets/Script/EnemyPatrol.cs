using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject _leftBorder;
    public GameObject _rightBorder;
    public Rigidbody2D _rigidbody;
    public SpriteRenderer _renderer;
    public Animator _animator;

    public bool _isRightDirection;

    public float speed;

    private void Update()
    {
        if(_isRightDirection)
        {
            _rigidbody.velocity = Vector2.right * speed;
            if(transform.position.x > _rightBorder.transform.position.x)
            {
                _isRightDirection = !_isRightDirection;
                _renderer.flipX = false;
            }
            
        }
        else
        {
            _rigidbody.velocity = Vector2.left * speed;
            if(transform.position.x < _leftBorder.transform.position.x)
            {
                _isRightDirection = true;
                _renderer.flipX = true;
            }
        }
    }


}
