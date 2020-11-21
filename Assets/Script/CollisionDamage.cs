using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage;
    [SerializeField] private Animator _animator;
    private Health health;
    private float direction;

    public float Direction
    {
        get { return direction; }
    }
        
    private void OnCollisionStay2D(Collision2D col)
    {
        health = col.gameObject.GetComponent<Health>();
        if(health != null)
        {
            direction = (col.transform.position - transform.position).x;
            _animator.SetFloat("Direction", Mathf.Abs(direction));
        }
        
    }

    public void SetDamage()
    {
        if(health != null)
        health.TakeHit(damage);
        health = null;
        direction = 0;
        _animator.SetFloat("Direction", 0f);
    }
}