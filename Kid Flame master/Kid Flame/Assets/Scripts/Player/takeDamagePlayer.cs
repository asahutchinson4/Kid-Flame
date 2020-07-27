using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * IMPORTANT: Added old shooting motion script to this one.
 * Allows kid flame to take damage but also the shooting
 * sprite when he shoots fireballs,
 */
public class takeDamagePlayer : MonoBehaviour
{

    public characterHealth health;
    public Sprite Shot;
    public Sprite Idle2;
    public Sprite Cold;
    public Sprite ColdShot;

    float timer = 1f;
    float delay = 1f;

    /*
     * If a water projectile collides with kidflame then
     * he will lose 5 health points and will
     * display hurt sprite.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Water"))
        {
            //health.ReduceHealth(5f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Cold;
            timer = delay;
            return;
        }
    }
   
    /*
     * Part of old shooting motion script.
     * If he is shooting a fireball then it will display
     * shooting sprite and play shooting sound. If timer is done 
     * then it will go back to idle sprite. If health equals 0
     * then kid flame dies. If kid flame's health gets below 40%
     * then he will stay blue.
     */
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.F) && health.normalizedHealth >= .4f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Shot;
            SoundManager.playFireballSound();
            timer = delay;
            return;
        }

        if (timer <= 0 && health.normalizedHealth >= .4f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Idle2;
        }

        if (Input.GetKeyDown(KeyCode.F) && health.normalizedHealth < .4f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ColdShot;
            SoundManager.playFireballSound();
            timer = delay;
            return;
        }

        if (timer <= 0 && health.normalizedHealth < .4f)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Cold;
        }

        if (health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
