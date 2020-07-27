using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject killedStamp;
    public GameObject sparedStamp;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject F;
    public GameObject goodBoy;
    public GameObject looseCannon;
    public GameObject madMan;
    public GameObject butcher;
    public GameObject psychopath;
         
    int fireCount;
    int localCount;

    public Text localScore;
    public Text fireScore;

    public characterHealth health;

    Boolean stopSoundFromRepeating = false;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        killedStamp.SetActive(false);
        sparedStamp.SetActive(false);
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        F.SetActive(false);
        goodBoy.SetActive(false);
        looseCannon.SetActive(false);
        madMan.SetActive(false);
        butcher.SetActive(false);
        psychopath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S) && Fate.enableKeyS == true)
        {
            StartCoroutine("WaitForNeedleSpared");
            StartCoroutine("DadWasSpared");
        }

        if (Input.GetKeyDown(KeyCode.F) && Fate.enableKeyF == true || health.currentHealth == 0 && stopSoundFromRepeating == false)
        {
            StartCoroutine("WaitForNeedleKilled");
            StartCoroutine("DadWasKilled");
            stopSoundFromRepeating = true;
        }

        if(karmaMeter.moral == 0)
        {
            A.SetActive(true);
            goodBoy.SetActive(true);
        }

        if (karmaMeter.moral > 0 && karmaMeter.moral <= 60)
        {
            B.SetActive(true);
            looseCannon.SetActive(true);
            A.SetActive(false);
            goodBoy.SetActive(false);
        }

        if (karmaMeter.moral > 60 && karmaMeter.moral <= 120)
        {
            C.SetActive(true);
            madMan.SetActive(true);
            A.SetActive(false);
            goodBoy.SetActive(false);
            B.SetActive(false);
            looseCannon.SetActive(false);
        }

        if (karmaMeter.moral > 120 && karmaMeter.moral <= 174)
        {
            D.SetActive(true);
            butcher.SetActive(true);
            A.SetActive(false);
            goodBoy.SetActive(false);
            B.SetActive(false);
            looseCannon.SetActive(false);
            C.SetActive(false);
            madMan.SetActive(false);
        }

        if (karmaMeter.moral > 174)
        {
            F.SetActive(true);
            psychopath.SetActive(true);
            A.SetActive(false);
            goodBoy.SetActive(false);
            B.SetActive(false);
            looseCannon.SetActive(false);
            C.SetActive(false);
            madMan.SetActive(false);
            D.SetActive(false);
            butcher.SetActive(false);
        }

        localScore.text = takeDamage.localCounter.ToString();
        fireScore.text = takeDamageFireFighter.fireCounter.ToString();
    }

    IEnumerator WaitForNeedleKilled()
    {
        yield return new WaitForSeconds(2);
        winScreen.SetActive(true);
    }
    
    IEnumerator WaitForNeedleSpared()
    {
        yield return new WaitForSeconds(1);
        winScreen.SetActive(true);
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
