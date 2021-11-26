using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


/*
 * Fades out music for when you find your dad.
 */
public class FadeOut : MonoBehaviour
{

    public AudioSource audio;

    public float fadeOutFactor;

    private bool fadeOut = false;

    /*
     * Update is called once per frame.
     * If audio volume is equal to or below zero
     * then the level music is destroyed. If fade out
     * equals true and the volume is above zero then 
     * the music will slowly fade out until the volume
     * reaches zero/it has been destroyed.
     */
    void Update()
    {
        if(audio.volume <= 0.0f)
        {
            audio.Stop();
            Destroy(this.gameObject);
        }

        if(fadeOut == true)
        {
            if(audio.volume > 0.0f)
            {
                audio.volume -= fadeOutFactor * Time.deltaTime;
            }
        }
    }

    /*
     * If Kid Flame enters the fade out box then
     * fade out is set to true.
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kid Flame"))
        {
            fadeOut = true;
        }
    }
}
