using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isCollisionDamage;
    private IoObjectDestroy destroy;

    

    public void Init(IoObjectDestroy destroy)
    {
        this.destroy = destroy;
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
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