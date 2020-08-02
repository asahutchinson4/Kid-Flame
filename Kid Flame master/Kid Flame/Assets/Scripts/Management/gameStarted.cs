using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStarted : MonoBehaviour
{
    public static bool gameHasStarted;

    // Start is called before the first frame update
    void Start()
    {
        gameHasStarted = true;
    }
}
