using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fate : MonoBehaviour
{
    public GameObject EndingPrompt;
    public GameObject BackBorder;
    public GameObject LeftBorder;
    public GameObject RightBorder;
    public GameObject BottomBorder;
    public GameObject TopBorder;
    public GameObject F;
    public GameObject S;

    public characterHealth health;

    public static bool enableKeyS = false;

    // Start is called before the first frame update
    void Start()
    {
        EndingPrompt.SetActive(false);
        BackBorder.SetActive(false);
        LeftBorder.SetActive(false);
        RightBorder.SetActive(false);
        BottomBorder.SetActive(false);
        TopBorder.SetActive(false);
        F.SetActive(false);
        S.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth == 0)
        {
            Destroy(EndingPrompt);
            Destroy(BackBorder);
            Destroy(LeftBorder);
            Destroy(RightBorder);
            Destroy(BottomBorder);
            Destroy(TopBorder);
            Destroy(F);
            Destroy(S);
        }

        if (Input.GetKeyDown(KeyCode.S) && enableKeyS == true)
        {
            Destroy(EndingPrompt);
            Destroy(BackBorder);
            Destroy(LeftBorder);
            Destroy(RightBorder);
            Destroy(BottomBorder);
            Destroy(TopBorder);
            Destroy(F);
            Destroy(S);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("WaitForDialog");
        }
    }

    IEnumerator WaitForDialog()
    {
        yield return new WaitForSeconds(33);
        EndingPrompt.SetActive(true);
        BackBorder.SetActive(true);
        LeftBorder.SetActive(true);
        RightBorder.SetActive(true);
        BottomBorder.SetActive(true);
        TopBorder.SetActive(true);
        F.SetActive(true);
        S.SetActive(true);
        enableKeyS = true;
    }
}
