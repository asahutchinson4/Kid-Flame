using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Cryptography;
using UnityEngine;

/*
 * Allows local to take damage
 */
public class takeDamage : MonoBehaviour
{
    public characterHealth health;
    public Sprite Hurt;
    public Sprite Local;

    public static int localCounter;
   
    float timer = 1f;
    float delay = 1f;

    void Start()
    {
        localCounter = 0;
    }
  
    /*
     * If a bullet collides with local then
     * he will lose 50 health points and will
     * display hurt sprite.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {

    if (col.gameObject.CompareTag("Bullet"))
        {
            health.ReduceHealth(50f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Hurt;
            timer = delay;
            return;
        }
        
    }

    /*
     * Update is called once per frame.
     * If timer is done then local will switch
     * back to idle sprite. If health equals 0
     * then local dissapears.
     */
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
            localCounter += 1;
        }
    }

}
