using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class spotted : MonoBehaviour
{
    public Sprite FireFighter;
    public Sprite FireFighterSpotted;
    public FireFighterController control;

    float timer = 10f;
    float delay = 5f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (control.kidDetected && Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighterSpotted;
            timer = delay;
            return;
        }
        if(timer <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighter;
        }
    }
}
