using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


/*
 * Fades in music for when you find your dad.
 */
public class FadeIn : MonoBehaviour
{

    public AudioSource audio;

    public float fadeInFactor;

    private bool fadeIn = false;

    /*
     * Start is called before the first frame update.
     * Sets voume to a low;
     */
    void Start()
    {
        audio.volume = 0.2f;
    }

    /*
     * Update is called once per frame.
     * If fade in equals true then the audio 
     * will play and the volume will slowly
     * go up.
     */
    void Update()
    {

        if(fadeIn == true)
        {
            audio.volume += fadeInFactor * Time.deltaTime;
            audio.Play();
        }
    }

    /*
     * If Kid Flame enters the fade in box then
     * fade in is set to true.
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Kid Flame"))
        {
            fadeIn = true;
        }
    }
}
