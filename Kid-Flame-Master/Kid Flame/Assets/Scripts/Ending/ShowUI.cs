using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Shows UI elements at the end of the game.
 * All dialog components.
 */
public class ShowUI : MonoBehaviour
{
    public GameObject KidIntro;
    public GameObject DadGreeting;
    public GameObject DadApology;
    public GameObject KidResponseToApology;
    public GameObject DadAdmit;
    public GameObject KidPain;
    public GameObject DadBeg;
    public GameObject KidFlame;
    public GameObject Scream;
    public GameObject Gratitude;

    public PlayerMovement kidScript;
    public characterHealth health;

    public static bool inDialogBox;

    /*
     * Start is called before the first frame update.
     * Sets all gameobjects to false. Sets player movement
     * script equal to kidScript and makes inDialogBox equal
     * false.
     */
    void Start()
    {
        KidIntro.SetActive(false);
        DadGreeting.SetActive(false);
        DadApology.SetActive(false);
        KidResponseToApology.SetActive(false);
        DadAdmit.SetActive(false);
        KidPain.SetActive(false);
        DadBeg.SetActive(false);
        Scream.SetActive(false);
        Gratitude.SetActive(false);

        kidScript = KidFlame.GetComponent<PlayerMovement>();

        inDialogBox = false;
    }

    /*
     * Update is called once per frame.
     * If dad's health quals zero then all gameobjects
     * will be destroyed. If key F is pressed and Kid Flame is
     * in the dialog box then activate scream and destroy all
     * other gameobjects. If key S is enabled and pressed and
     * Kid Flame is in the dialog box then activate gratitude
     * gameobject.
     */
    void Update()
    {
        if (health.currentHealth == 0)
        {
            Destroy(DadGreeting);
            Destroy(KidIntro);
            Destroy(DadApology);
            Destroy(KidResponseToApology);
            Destroy(DadAdmit);
            Destroy(KidPain);
            Destroy(DadBeg);
            Destroy(Scream);
            Destroy(Gratitude);
        }

        if(Input.GetKeyDown(KeyCode.F) && inDialogBox == true)
        {
            Scream.SetActive(true);
            Destroy(DadGreeting);
            Destroy(KidIntro);
            Destroy(DadApology);
            Destroy(KidResponseToApology);
            Destroy(DadAdmit);
            Destroy(KidPain);
            Destroy(DadBeg);
            Destroy(Gratitude);
        }

        if (Input.GetKeyDown(KeyCode.S) && inDialogBox == true && Fate.enableKeyS == true)
        {
            Gratitude.SetActive(true);
        }
    }
    
    /*
     * Once Kid Flame enters the dialog box he will
     * not be able to move. Then Coroutines and IEnumerators
     * begin that show dialog between dad and Kid Flame.
     */
   public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kid Flame"));
        {
            kidScript.moveSpeed = 0f;
            kidScript.jumpVelocity = 0f;
            inDialogBox = true;
        }

        if (col.gameObject.CompareTag("Kid Flame"));
        {
            DadGreeting.SetActive(true);
            StartCoroutine("WaitForSec1");
        }

        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking1");
            StartCoroutine("WaitForSec2");
        }

        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking2");
            StartCoroutine("WaitForSec3");
        }

        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking3");
            StartCoroutine("WaitForSec4");
        }

        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking4");
            StartCoroutine("WaitForSec5");
        }

        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking5");
            StartCoroutine("WaitForSec6");
        }
        
        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("FinishTalking6");
            StartCoroutine("WaitForSec7");
        }
    }


    IEnumerator WaitForSec1()
    {
        yield return new WaitForSeconds(3);
        Destroy(DadGreeting);
    }

    IEnumerator FinishTalking1()
    {
        yield return new WaitForSeconds(3);
        KidIntro.SetActive(true);
    }

    IEnumerator WaitForSec2()
    {
        yield return new WaitForSeconds(7);
        Destroy(KidIntro);
    }

    IEnumerator FinishTalking2()
    {
        yield return new WaitForSeconds(7);
        DadApology.SetActive(true);
    }

    IEnumerator WaitForSec3()
    {
        yield return new WaitForSeconds(12);
        Destroy(DadApology);
    }

    IEnumerator FinishTalking3()
    {
        yield return new WaitForSeconds(12);
        KidResponseToApology.SetActive(true);
    }

    IEnumerator WaitForSec4()
    {
        yield return new WaitForSeconds(18);
        Destroy(KidResponseToApology);
    }

    IEnumerator FinishTalking4()
    {
        yield return new WaitForSeconds(18);
        DadAdmit.SetActive(true);
    }

    IEnumerator WaitForSec5()
    {
        yield return new WaitForSeconds(24);
        Destroy(DadAdmit);
    }

    IEnumerator FinishTalking5()
    {
        yield return new WaitForSeconds(24);
        KidPain.SetActive(true);
    }

    IEnumerator WaitForSec6()
    {
        yield return new WaitForSeconds(28);
        Destroy(KidPain);
    }

    IEnumerator FinishTalking6()
    {
        yield return new WaitForSeconds(28);
        DadBeg.SetActive(true);
    }

    IEnumerator WaitForSec7()
    {
        yield return new WaitForSeconds(32);
        Destroy(DadBeg);
    }
}
