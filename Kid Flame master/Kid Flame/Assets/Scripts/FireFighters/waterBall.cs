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
    public float speed;
    public Rigidbody2D rb;
    public FireFighterController fire;
    private Vector2 shooting;
    private int direction;


    /*
     * Start is called before the first frame update.
     * Assigns rigidbody, velocity and object reference
     * facingDirection.
     */
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        shooting = new Vector2(speed, 0f);
        rb.velocity = shooting;

        fire = GameObject.Find("Killers").GetComponent<FireFighterController>();
        direction = fire.facingDirection;
    }

    /*
     * Update is called once per frame.
     * If firefighter is facing right then he
     * shoots to the right and if he is facing
     * left then he shoots to the left.
     */
    void Update()
    { 

        if (direction == 1)
        {
            shooting.Set(speed, 0f);
            rb.velocity = shooting;
        }

        if (direction == -1)
        {
            shooting.Set(speed * -1, 0f);
            rb.velocity = shooting;
        }
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
    }
}
