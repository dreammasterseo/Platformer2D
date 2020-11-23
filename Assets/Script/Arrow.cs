using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IoObjectDestroy
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float force;
    [SerializeField] private float liveTiame;
    [SerializeField] private Vector2 _transform;
    [SerializeField] private TriggerDamage triggerDamage;
    private Player player;
    public float Force
    {
        get { return force; }
        set { force = value; }
    }
    public void Destroy(GameObject gameObject)
    {
        player.ReturnArrowToPoll(this);
    }
    public void SetImpuls(Vector2 direction, float force, Player player)
    {
        this.player = player;
        rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        if(force < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        StartCoroutine(StartLive());
    }

    private void Upate()
    {
       
        SetImpuls(_transform, force, this.player);
    }



    private IEnumerator StartLive()
    {
        yield return new WaitForSeconds(liveTiame);
        Destroy(gameObject);
        yield break;
    }

    
}
