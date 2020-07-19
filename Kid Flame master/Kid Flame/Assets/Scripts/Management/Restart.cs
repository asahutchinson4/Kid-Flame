using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject restartButton;

    public characterHealth health;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth == 0)
        {
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Kid Flame Scene");
    }
}
