using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamageFireFighter : MonoBehaviour
{
    public FireFighterHealth FireHealth;
    public Sprite FireFighterHurt;
    public Sprite FireFighter;

    float timer = 1f;
    float delay = 1f;


    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Bullet"))
        {
            FireHealth.FireReduceHealth(15f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighterHurt;
            timer = delay;
            return;
        }

    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighter;
        }

        if (FireHealth.FirecurrentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
