using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Class for quit prompt once Kid Flame
 * is dead.
 */
public class Quit : MonoBehaviour
{
    public GameObject quitButton;

    public characterHealth health;

    /*
     * Start is called before the first frame update.
     * quitButton is disabled.
     */
    void Start()
    {
        quitButton.SetActive(false);
    }

    /*
     * Update is called once per frame.
     * If Kid Flame's health equals zero then
     * you will be prompted to quit.
     */
    void Update()
    {
        if (health.currentHealth == 0)
        {
            quitButton.SetActive(true);
        }
    }

    /*
     * Loads MainMenu Scene.
     */
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
