using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Allows firefighters to take damage
 */
public class takeDamageFireFighter : MonoBehaviour
{
    public characterHealth FireHealth;
    public Sprite FireFighterHurt;
    public Sprite FireFighter;

    public static int fireCounter;

    float timer = 1f;
    float delay = 1f;

    void Start()
    {
        fireCounter = 0;
    }

    /*
     * If a bullet collides with firefighter then
     * he will lose 15 health points and will
     * display hurt sprite.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Bullet"))
        {
            FireHealth.ReduceHealth(15f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighterHurt;
            timer = delay;
            return;
        }

    }

    /*
     * Update is called once per frame.
     * If timer is done then firefighter will switch
     * back to idle sprite. If health equals 0
     * then firefighter dissapears.
     */
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireFighter;
        }

        if (FireHealth.currentHealth == 0)
        {
            Destroy(this.gameObject);
            fireCounter += 1;
            SoundManager.playCheers();
        }
    }
}
