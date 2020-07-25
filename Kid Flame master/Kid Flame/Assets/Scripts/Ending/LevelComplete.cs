using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject killedStamp;
    public GameObject sparedStamp;
    public GameObject dadSprite;
    public GameObject completionText;

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
        if (Input.GetKeyDown(KeyCode.S) && Fate.enableKeyS == true)
        {
            StartCoroutine("WaitForNeedle");
            StartCoroutine("DadWasSpared");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("WaitForNeedle");
            StartCoroutine("DadWasKilled");
        }
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
        killedStamp.SetActive(true);
    }

    IEnumerator DadWasSpared()
    {
        yield return new WaitForSeconds(4);
        sparedStamp.SetActive(true);
    }
}
