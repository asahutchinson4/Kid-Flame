using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public GameObject quitButton;

    public characterHealth health;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth == 0)
        {
            quitButton.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
