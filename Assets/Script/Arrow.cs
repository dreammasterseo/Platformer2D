using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float force;
    [SerializeField] private float liveTiame;
    [SerializeField] private Vector2 _transform;
    public float Force
    {
        get { return force; }
        set { force = value; }
    }

    public void SetImpuls(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
        if(force < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        StartCoroutine(StartLive());
    }

    private void Upate()
    {
       
        SetImpuls(_transform, force);
    }



    private IEnumerator StartLive()
    {
        yield return new WaitForSeconds(liveTiame);
        Destroy(gameObject);
        yield break;
    }
}
