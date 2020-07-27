using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manages all sound in the game.
 */
public class SoundManager : MonoBehaviour
{

    public static AudioClip fireBallSound;
    static AudioSource audioSrc;
    public static AudioClip carBlowUp;
    public static AudioClip stamp;


    /*
     * Start is called before the first frame update.
     * Assigns Audiosource and Audioclips.
     */
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        fireBallSound = Resources.Load<AudioClip>("FireThrow");
        carBlowUp = Resources.Load<AudioClip>("CarExploding");
        stamp = Resources.Load<AudioClip>("Stamp");
    }

    /* 
     * Plays sound when kidflame shoots fireball.
     */
    public static void playFireballSound()
    {
        audioSrc.PlayOneShot(fireBallSound);
    }

    /*
     * Plays sound when car blows up
     */
    public static void playCarBlowUpSound()
    {
        audioSrc.PlayOneShot(carBlowUp);
    }

    public static void playStampSound()
    {
        audioSrc.PlayOneShot(stamp);
    }
}
