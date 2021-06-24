using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
   
    [SerializeField]private  float _health;
    public float CurrentHealth
    {
        get { return _health; }
        set { _health = value; }
    }

    private void OnValidate()
    {
        if (_health <= 0)
            _health = 0;
        if (_health >= 100)
            _health = 100;
    }

    public static Health Instance;
    private void Start()
    {
        Instance = this;
        GameManager.Instance.healthContainer.Add(gameObject, this);
    }

    public void TakeHit(float damage)
    {
        CurrentHealth -= damage;
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
       
    }

    public void SetHealth(int health)
    {
        CurrentHealth += health;
        if(_health >= 100)
        {
            _health = 100;
        }
    }
}
