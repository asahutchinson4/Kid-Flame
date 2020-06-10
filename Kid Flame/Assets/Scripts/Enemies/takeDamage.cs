using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public EnemyHealth health;
    public Sprite Hurt;
    public Sprite Local;
   
    float timer = 1f;
    float delay = 1f;
  

    public void OnCollisionEnter2D(Collision2D col)
    {

    if (col.gameObject.CompareTag("Bullet"))
        {
            health.ReduceHealth(15f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Hurt;
            timer = delay;
            return;
        }
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Local;
        }

        if(health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
