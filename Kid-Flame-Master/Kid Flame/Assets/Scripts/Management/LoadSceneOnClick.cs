using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Loads scene when button is clicked.
 */
public class LoadSceneOnClick : MonoBehaviour
{
    
    /*
     * Will load particular scene of your
     * choosing.
     */
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
