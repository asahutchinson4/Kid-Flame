using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

/*
 * Manages most sound in the game.
 */
public class SoundManager : MonoBehaviour
{

    static AudioSource audioSrc;
    public static AudioClip fireBallSound;
    public static AudioClip carBlowUp;
    public static AudioClip stamp;
    public static AudioClip theme;
    public static AudioClip hover;
    public static AudioClip click;
    public static AudioClip waterPop;
    public static AudioClip splash;
    public static AudioClip sizzle;
    public static AudioClip cheers;
    public static AudioClip jump;
    public static AudioClip fate;

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
        theme = Resources.Load<AudioClip>("ThemeSong");
        hover = Resources.Load<AudioClip>("Hover");
        click = Resources.Load<AudioClip>("Click");
        waterPop = Resources.Load<AudioClip>("WaterPop");
        splash = Resources.Load<AudioClip>("Splash");
        sizzle = Resources.Load<AudioClip>("Sizzle");
        cheers = Resources.Load<AudioClip>("Cheers");
        jump = Resources.Load<AudioClip>("Jump");
        fate = Resources.Load<AudioClip>("Fate");
    }

    /* 
     * Plays sound when kidflame shoots fireball.
     */
    public static void playFireballSound()
    {
        audioSrc.PlayOneShot(fireBallSound);
    }

    /*
     * Plays sound when car blows up.
     */
    public static void playCarBlowUpSound()
    {
        audioSrc.PlayOneShot(carBlowUp);
    }

    /*
     * Plays stamp sound.
     */
    public static void playStampSound()
    {
        audioSrc.PlayOneShot(stamp);
    }

    /*
     * Plays theme song.
     */
    public static void playThemeSong()
    {
        audioSrc.PlayOneShot(theme);
    }

    /*
     * Plays hovering sound.
     */
    public static void playHoverSound()
    {
        audioSrc.PlayOneShot(hover);
    }

    /*
     * Plays click sound.
     */
    public static void playClickSound()
    {
        audioSrc.PlayOneShot(click);
    }

    /*
     * Plays water spray sound.
     */
    public static void playerWaterShot()
    {
        audioSrc.PlayOneShot(waterPop);
    }

    /*
     * Plays splash sound.
     */
    public static void playSplash()
    {
        audioSrc.PlayOneShot(splash);
    }

    /*
     * Plays sizzle sound.
     */
    public static void playSizzle()
    {
        audioSrc.PlayOneShot(sizzle);
    }

    /*
     * Plays cheers sound.
     */
    public static void playCheers()
    {
        audioSrc.PlayOneShot(cheers);
    }

    /*
     * Plays jump sound.
     */
    public static void playJumpSound()
    {
        audioSrc.PlayOneShot(jump);
    }

    /*
     * Plays fate song.
     */
    public static void playFateMusic()
    {
        audioSrc.PlayOneShot(fate);
    }
}
