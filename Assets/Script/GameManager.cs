using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    #endregion
    public Dictionary<GameObject, Health> healthContainer;
    public Dictionary<GameObject, Coins> coinsContainer;
    private void Awake()
    {
        Instance = this;
        healthContainer = new Dictionary<GameObject, Health>();
        coinsContainer = new Dictionary<GameObject, Coins>();
    }
}
