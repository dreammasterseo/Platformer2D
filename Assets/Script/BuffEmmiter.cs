using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmmiter : MonoBehaviour
{
    [SerializeField] private Buff buff;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GameManager.Instance.buffResiverContainer.ContainsKey(col.gameObject))
        {
            var resiver = GameManager.Instance.buffResiverContainer[col.gameObject];
            resiver.AddBuff(buff);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (GameManager.Instance.buffResiverContainer.ContainsKey(col.gameObject))
        {
            var resiver = GameManager.Instance.buffResiverContainer[col.gameObject];
            resiver.RemoveBuff(buff);
        }
    }



}

//[System.Serializable]
public class Buff
{
    public ByffType type;
    public float additiveBonus;
    public float multipleBonus;
}

public enum ByffType : byte
{
    Damage, force, Armor
}
