using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage;
    public string _collisionTag;
    private Animator _animator;

    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag(_collisionTag))
        {
           col.gameObject.GetComponent<Health>().TakeHit(damage);
           _animator = GetComponent<Animator>();
           _animator.SetBool("isBiting", true);
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag(_collisionTag))
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool("isBiting", false);
        }
    }
}
