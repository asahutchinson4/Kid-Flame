using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FadeIn : MonoBehaviour
{

    public AudioSource audio;

    public float fadeInFactor;

    private bool fadeIn = false;

    // Start is called before the first frame update
    void Start()
    {
        audio.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

        if(fadeIn == true)
        {
            audio.volume += fadeInFactor * Time.deltaTime;
            audio.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Kid Flame"))
        {
            fadeIn = true;
        }
    }
}
