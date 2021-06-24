using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private bool isCollisionDamage;
    private IoObjectDestroy destroy;

    

    public void Init(IoObjectDestroy destroy)
    {
        this.destroy = destroy;
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(GameManager.Instance.healthContainer.ContainsKey(col.gameObject))
            {
                var health = GameManager.Instance.healthContainer[col.gameObject];
                    health.TakeHit(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {      
            if(GameManager.Instance.healthContainer.ContainsKey(col.gameObject))
            {
                var health = GameManager.Instance.healthContainer[col.gameObject];
                health.TakeHit(damage);
            }

            if(isCollisionDamage == true)
            {
                if (destroy == null)
                    Destroy(gameObject);
                else
                    destroy.Destroy(gameObject);
            } 
        }
    }
}


 public interface IoObjectDestroy
{
    void Destroy(GameObject gameObject);
}