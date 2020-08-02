using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    GameObject otherSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

    void Update()
    {
        if(gameStarted.gameHasStarted == true)
        {
            Destroy(this.gameObject);
        }
    }
}
