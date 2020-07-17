using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Decides the direction the fireball will go,
 * the speed of it and when it will be destroyed.
 */
public class Fireball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    /*
     * Start is called before the first frame update.
     * Assigns rigidbody and velocity.
     */
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }



    /* 
     * Update is called once per frame.
     * If the fireball is off screen then it is destroyed.
     */
    void FixedUpdate()
    {

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

        /* If the tag matches then the fireball will
        *  be destroyed.
        */
       private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Car"))
            {
                Destroy(gameObject);
                SoundManager.playCarBlowUpSound();
            }
            if (col.gameObject.CompareTag("Cloud"))
            {
                Destroy(gameObject);
            }
            if (col.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            if (col.gameObject.CompareTag("Killer"))
            {
                Destroy(gameObject);
            }
            if (col.gameObject.CompareTag("Water"))
            {
                Destroy(gameObject);
            }
            if (col.gameObject.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
            if (col.gameObject.CompareTag("Dad"))
            {
                Destroy(gameObject);
            }

    }

}
