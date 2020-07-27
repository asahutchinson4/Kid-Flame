using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

/*
 * Decides the direction the water projectile will go,
 * the speed of it and when it will be destroyed.
 */
public class waterBall : MonoBehaviour
{
    public Rigidbody2D rb;
    public FireFighterController fire;
    public Vector2 shooting;


    /*
     * Start is called before the first frame update.
     * Assigns rigidbody and velocity.
     */
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = shooting;
    }


    /*
     * If the tag matches then the water projectile will
     * be destroyed.
     */
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Kid Flame"))
        {
            Destroy(gameObject);
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
        if (col.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
