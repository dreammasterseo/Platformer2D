using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int _health;

    public void TakeHit(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int health)
    {
        _health += health;
        if(_health >= 100)
        {
            _health = 100;
        }
    }
}
