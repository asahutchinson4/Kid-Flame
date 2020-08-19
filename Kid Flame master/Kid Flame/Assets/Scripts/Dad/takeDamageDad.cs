using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class for dad taking damage from Kid Flame.
 */
public class takeDamageDad : MonoBehaviour
{
    public characterHealth health;

    public static int dadCounter;

    /*
     * Start is called before the first frame update.
     * Sets the counter for dad to zero and his health to full.
     */
    void Start()
    {
        dadCounter = 0;
        health.currentHealth = 100;
        health.normalizedHealth = 1;
    }

    /*
     * If a fire projectile collides with dad
     * then he dies.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health.ReduceHealth(100f);
        }
    }

    /*
     * Update is called once per frame.
     * If dad's health equals zero then he
     * is destroyed and the dad counter will equal
     * one.
     */
    void Update()
    {
        if (health.currentHealth == 0)
        {
            Destroy(this.gameObject);
            dadCounter += 1;
        }
    }
}
