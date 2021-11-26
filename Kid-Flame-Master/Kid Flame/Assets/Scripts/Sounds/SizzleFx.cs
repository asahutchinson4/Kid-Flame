using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for sizzle sound.
 */
public class SizzleFx : MonoBehaviour
{
    /*
     * If water collides with KidFlame then the sound will play.
     */
   public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            SoundManager.playSizzle();
        }
    }
}
