using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizzleFx : MonoBehaviour
{
   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            SoundManager.playSizzle();
        }
    }
}
