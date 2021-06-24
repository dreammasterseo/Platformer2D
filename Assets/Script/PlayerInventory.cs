using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int _coinsCount;
    [SerializeField] private Text coinsText;

    private void Start()
    {
        coinsText.text = _coinsCount.ToString();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GameManager.Instance.coinsContainer.ContainsKey(col.gameObject))
        {
            _coinsCount ++;
            coinsText.text = _coinsCount.ToString();
            var coins = GameManager.Instance.coinsContainer[col.gameObject];
            coins.StartDestroy();
        }

        if(col.gameObject.CompareTag("HelthPotion"))
        {
            GetComponent<Health>().SetHealth(5);
            Destroy(col.gameObject);
        }
    }
    private void Update()
    {
        _coinsCount += Coins._coinsCount;
    }
}


