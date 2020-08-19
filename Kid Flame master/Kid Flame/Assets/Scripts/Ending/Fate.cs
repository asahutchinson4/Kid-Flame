using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class for bringing up the prompt once dad
 * and Kid Flame are done speaking. It gives
 * the player a choice to spare or kill his 
 * father. Important booleans are here to
 * enable keys.
 */
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
    public static bool enableKeyF = false;

    /*
     * Start is called before the first frame update.
     * Sets all gameobjects to false.
     */
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

    /*
     * Update is called once per frame.
     * First checks if dad's health equals zero then
     * all gameobjects will be destroyed. Then if
     * key S is enabled and pressed then it will destroy
     * the gameobjects.
     */
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

    /*
     * When Kid Flame enters the fate (trigger) box
     * then it starts WaitForDialog().
     */
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kid Flame"))
        {
            StartCoroutine("WaitForDialog");
        }
    }

    /*
     * After 33 seconds have passed, the prompt will appear
     * and the player can either click S or F to end 
     * the game.
     */
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
        enableKeyF = true;
    }
}
