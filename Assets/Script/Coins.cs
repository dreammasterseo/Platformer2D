using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public static int _coinsCount;
    [SerializeField] private Animator animator;

    private void Start()
    {
        GameManager.Instance.coinsContainer.Add(gameObject, this);
    }


    public void StartDestroy()
    {
        animator.SetTrigger("DestroyCoins");
    }

    private void EndDestroy()
    {
        Destroy(gameObject);
    }

}