using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for button sounds on Main Menu.
 */
public class ButtonSounds : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hover;
    public AudioClip click;

    /*
     * Sound for when you hover above button.
     */
    public void HoverSound()
    {
        myFx.PlayOneShot(hover);
    }

    /*
     * Sound for when you click button.
     */
    public void ClickSound()
    {
        myFx.PlayOneShot(click);
    }
}
