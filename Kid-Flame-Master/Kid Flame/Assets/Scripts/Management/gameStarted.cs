using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class holding boolean for when game
 * has started.
 */
public class gameStarted : MonoBehaviour
{
    public static bool gameHasStarted;

    /*
     * Start is called before the first frame update.
     * gameHasStarted is set to true.
     */
    void Start()
    {
        gameHasStarted = true;
    }
}
