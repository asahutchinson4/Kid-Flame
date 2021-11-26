using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for splash sound.
 */
public class SplashFx : MonoBehaviour
{
    /*
     * When object(cars) is collided with water it plays
     * the splash sound.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            SoundManager.playSplash();
        }
    }
}
