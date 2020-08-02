using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hover;
    public AudioClip click;

    public void HoverSound()
    {
        myFx.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(click);
    }
}
