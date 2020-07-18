using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject KidIntro;
    public GameObject DadGreeting;
    public GameObject DadApology;
    public GameObject KidResponseToApology;
    public GameObject DadAdmit;
    public GameObject KidPain;

    // Start is called before the first frame update
    void Start()
    {
        KidIntro.SetActive(false);
        DadGreeting.SetActive(false);
        DadApology.SetActive(false);
        KidResponseToApology.SetActive(false);
        DadAdmit.SetActive(false);
        KidPain.SetActive(false);
    }

   public void OnTriggerEnter2D(Collider2D col)
    {
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
}
