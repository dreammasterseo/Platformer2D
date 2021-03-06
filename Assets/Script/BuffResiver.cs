using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffResiver : MonoBehaviour
{
    private List<Buff> buffs;
    void Start()
    {
        GameManager.Instance.buffResiverContainer.Add(gameObject, this);
        buffs = new List<Buff>();
    }

    public void AddBuff(Buff buff)
    {
        if (!buffs.Contains(buff))
            buffs.Add(buff);
    }

    public void RemoveBuff(Buff buff)
    {
        if(buffs.Contains(buff))
        {
            buffs.Remove(buff);
        }
    }
}
