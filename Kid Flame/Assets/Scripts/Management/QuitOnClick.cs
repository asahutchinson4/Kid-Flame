using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If the quit button is clicked then the program
 * ends.
 */
public class QuitOnClick : MonoBehaviour
{
  public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit;
#endif
    }
} 
