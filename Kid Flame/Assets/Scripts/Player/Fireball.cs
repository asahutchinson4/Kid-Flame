using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
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
    }
    
}
