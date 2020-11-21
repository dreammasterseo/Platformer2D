using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject _leftBorder;
    public GameObject _rightBorder;
    public Rigidbody2D _rigidbody;
    public SpriteRenderer _renderer;
    public GraundDetection _graundDetection;
    public bool _isRightDirection;
    public CollisionDamage _collisionDamage;
    public float speed;

    private void Update()
    {

        if(_graundDetection._isGraund)
        {
            if (transform.position.x > _rightBorder.transform.position.x || _collisionDamage.Direction < 0)

                _isRightDirection = false;
            else if (transform.position.x < _leftBorder.transform.position.x || _collisionDamage.Direction > 0)
                _isRightDirection = true;
            _rigidbody.velocity = _isRightDirection ? Vector2.right : Vector2.left;
            _rigidbody.velocity *= speed;
        }

        if(_rigidbody.velocity.x > 0)
        {
            _renderer.flipX = true;
        }
        if (_rigidbody.velocity.x < 0)
        {
            _renderer.flipX = false;
        }

    }


}
