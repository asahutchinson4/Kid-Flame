using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class for game music.
 */
public class GameMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    GameObject otherSound;
    AudioSource audioSource;

    /*
     * Start is called before the first frame update.
     * Gets audiosource.
     */
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /*
     * Finds game music. Basically this is used so the music
     * does not stop or restart when you sift through the different
     * panels of the main menu.
     */
    void Awake()
    {
        otherSound = GameObject.FindGameObjectWithTag("Game Music");

        if (otherSound == this.gameObject)
        {
            if (!AudioBegin)
            {
                DontDestroyOnLoad(this.gameObject);
                AudioBegin = true;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * Update is called once per frame.
     * If game has startes equals true then the main menu music
     * will be destroyed.
     */
    void Update()
    {
        if(gameStarted.gameHasStarted == true)
        {
            Destroy(this.gameObject);
        }
    }
}
