using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip fireBallSound;
    static AudioSource audioSrc;
    public static AudioClip carBlowUp;


    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource> ();
        fireBallSound = Resources.Load<AudioClip>("FireThrow");
        carBlowUp = Resources.Load<AudioClip>("CarExploding");
    }

    public static void playFireballSound()
    {
        audioSrc.PlayOneShot(fireBallSound);
    }

    public static void playCarBlowUpSound()
    {
        audioSrc.PlayOneShot(carBlowUp);
    }
}
