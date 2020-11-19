using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int _coinsCount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Coin"))
        {
            _coinsCount += 1;
            Destroy(col.gameObject);
        }

        if(col.gameObject.CompareTag("HelthPotion"))
        {
            GetComponent<Health>().SetHealth(5);
            Destroy(col.gameObject);
        }
    }

}
