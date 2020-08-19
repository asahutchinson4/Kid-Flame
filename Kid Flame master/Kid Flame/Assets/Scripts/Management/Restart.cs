using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Class for restart prompt once Kid Flame
 * is dead.
 */
public class Restart : MonoBehaviour
{
    public GameObject restartButton;

    public characterHealth health;

    /*
    * Start is called before the first frame update.
    * restartButton is disabled.
    */
    void Start()
    {
        restartButton.SetActive(false);
    }

    /*
     * Update is called once per frame.
     * If Kid Flame's health equals zero then
     * you will be prompted to restart.
     */
    void Update()
    {
        if (health.currentHealth == 0)
        {
            restartButton.SetActive(true);
        }
    }

    /*
     * Resets the game. Three booleans are set to 
     * false so that you can't pop the win screen from
     * the beginning.
     */
    public void RestartGame()
    {
        SceneManager.LoadScene("Kid Flame Scene");
        ShowUI.inDialogBox = false;
        Fate.enableKeyF = false;
        Fate.enableKeyS = false;
    }
}
