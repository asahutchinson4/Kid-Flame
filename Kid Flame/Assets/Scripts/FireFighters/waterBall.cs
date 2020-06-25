using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class waterBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public FireFighterController fire;
    private Vector2 shooting;
    private static int direction;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        shooting = new Vector2(speed, 0f);
        rb.velocity = shooting;

        direction = FireFighterController.facingDirection;
    }

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
