using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject KidIntro;
    public GameObject DadGreeting;

    // Start is called before the first frame update
    void Start()
    {
        KidIntro.SetActive(false);
        DadGreeting.SetActive(false);
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
    }

    IEnumerator FinishTalking1()
    {
        yield return new WaitForSeconds(3);
        KidIntro.SetActive(true);
    }

    IEnumerator WaitForSec1()
    {
        yield return new WaitForSeconds(3);
        Destroy(DadGreeting);
    }
    
    IEnumerator WaitForSec2()
    {
        yield return new WaitForSeconds(7);
        Destroy(KidIntro);
    }
}
