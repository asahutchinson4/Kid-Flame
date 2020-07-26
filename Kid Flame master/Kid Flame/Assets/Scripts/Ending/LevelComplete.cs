using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject killedStamp;
    public GameObject sparedStamp;
    public GameObject dadSprite;
    public GameObject completionText;
    public GameObject fireman;
    public GameObject local;

    int fireCount;
    int localCount;

    public Text localScore;
    public Text fireScore;

    public characterHealth health;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        killedStamp.SetActive(false);
        sparedStamp.SetActive(false);
        dadSprite.SetActive(false);
        completionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (health.currentHealth == 0)
        {
            StartCoroutine("WaitForNeedle");
            StartCoroutine("DadWasKilled");
        }

        if (Input.GetKeyDown(KeyCode.S) && Fate.enableKeyS == true)
        {
            StartCoroutine("WaitForNeedle");
            StartCoroutine("DadWasSpared");
        }

        if (Input.GetKeyDown(KeyCode.F) && Fate.enableKeyF == true)
        {
            StartCoroutine("WaitForNeedle");
            StartCoroutine("DadWasKilled");
        }

        localScore.text = takeDamage.localCounter.ToString();
        fireScore.text = takeDamageFireFighter.fireCounter.ToString();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
       
    }

    IEnumerator WaitForNeedle()
    {
        yield return new WaitForSeconds(2);
        winScreen.SetActive(true);
        dadSprite.SetActive(true);
        completionText.SetActive(true);
    }

    IEnumerator DadWasKilled()
    {
        yield return new WaitForSeconds(4);
        SoundManager.playStampSound();
        killedStamp.SetActive(true);
    }

    IEnumerator DadWasSpared()
    {
        yield return new WaitForSeconds(4);
        SoundManager.playStampSound();
        sparedStamp.SetActive(true);
    }
}
