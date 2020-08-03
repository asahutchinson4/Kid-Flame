using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    public AudioSource audio;

    public float fadeOutFactor;

    private bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kid Flame"))
        {
            fadeOut = true;
        }
    }
}
