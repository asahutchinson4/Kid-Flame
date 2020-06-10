using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMotion : MonoBehaviour
{
    public Sprite Shot;
    public Sprite Idle2;

    float timer = 1f;
    float delay = 1f;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Shot;
            SoundManager.playFireballSound();
            timer = delay;
            return;
        }
        if (timer <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Idle2;
        }
    }
}
