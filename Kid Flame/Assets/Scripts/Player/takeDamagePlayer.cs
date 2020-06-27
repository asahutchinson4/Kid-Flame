using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamagePlayer : MonoBehaviour
{

    public characterHealth health;
    public Sprite Shot;
    public Sprite Idle2;
    public Sprite Cold;

    float timer = 1f;
    float delay = 1f;

    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Water"))
        {
            health.ReduceHealth(5f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Cold;
            timer = delay;
            return;
        }
    }
   
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

        if (health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
