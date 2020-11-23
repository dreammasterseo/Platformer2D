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
    [SerializeField] private Arrow gameObjectArrow;
    [SerializeField] private Transform _transform;
    [SerializeField] private float force;
    [SerializeField] private bool isReload;
    [SerializeField] private int arrowCount = 3;
    private List<Arrow> arrowsPool;
    void Start()
    {
        arrowsPool = new List<Arrow>();
        for (int i = 0; i < arrowCount; i++)
        {
            var arrow = Instantiate(gameObjectArrow, _transform);
            arrowsPool.Add(arrow);
            arrow.gameObject.SetActive(false);
        }
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        _animator.SetBool("isGrounded", _graundDetection._isGraund);
        if (!_isJumping && !_graundDetection._isGraund)
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


        _animator.SetFloat("Speed", Mathf.Abs(direction.x));

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isReload == true && _graundDetection._isGraund)
        {
            _animator.SetTrigger("Archery");
        }
    }

   
    void CheckShoot()
    {
        Arrow prefab = GetArrowFromPool();
        prefab.SetImpuls(Vector2.right, _spriteRenderer.flipX ? -force * 5 : force * 5, this);
        isReload = false;
        StartCoroutine(ReloadArow());
    }

    public void ReturnArrowToPoll(Arrow arrow)
    {
        if(!arrowsPool.Contains(arrow))
            arrowsPool.Add(arrow);
        
        arrow.transform.parent = _transform;
        arrow.transform.position = _transform.position;
        arrow.gameObject.SetActive(false);
    }
    private Arrow GetArrowFromPool()
    {
        if (arrowsPool.Count > 0)
        {
            var arrow = arrowsPool[0];
            arrowsPool.Remove(arrow);
            arrow.gameObject.SetActive(true);
            arrow.transform.parent = null;
            arrow.transform.position = _transform.position;
            return arrow;
        }
        return Instantiate(gameObjectArrow, _transform.position, Quaternion.identity);
    }
    private IEnumerator ReloadArow()
    {
        yield return new WaitForSeconds(3f);
        isReload = true;
        yield break;
    }
}
