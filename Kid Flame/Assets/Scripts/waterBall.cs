using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterBall : MonoBehaviour
{
    public float speed = 25.0f;
    private Rigidbody2D rb;
    public FireFighterController fireMan;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if (fireMan.facingDirection == 1f)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed * -1f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
