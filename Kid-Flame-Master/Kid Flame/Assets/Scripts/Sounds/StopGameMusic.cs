using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for stopping game music.
 */
public class StopGameMusic : MonoBehaviour
{
    public GameObject gameMusic;

    /*
     * Stops game music.
     */
    public void StopMusic()
    {
        Destroy(gameMusic);
    }
}
