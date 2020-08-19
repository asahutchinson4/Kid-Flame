using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If the quit button is clicked then the program
 * ends.
 */
public class QuitOnClick : MonoBehaviour
{
    /*
     * Quits program/
     */
  public void Quit()
    {
      Application.Quit();
    }
} 
