using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameMusic : MonoBehaviour
{
    public GameObject gameMusic;

    public void StopMusic()
    {
        Destroy(gameMusic);
    }
}
