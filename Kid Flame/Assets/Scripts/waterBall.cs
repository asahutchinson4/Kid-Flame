using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public FireFighterController fire;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);

       
    }

    void FixedUpdate()
    {
        if (fire.facingDirection == 1)
        {
            rb.velocity = new Vector2(speed, 0);
        }

        else if (fire.facingDirection == -1)
        {
            rb.velocity = new Vector2(speed * -1, 0);
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
    }
}
