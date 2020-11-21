using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundDetection : MonoBehaviour
{
    public bool _isGraund;


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Graund"))
        {
            _isGraund = true;
        }
    }
   
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Graund"))
        {
            _isGraund = false;
        }
    }


}
