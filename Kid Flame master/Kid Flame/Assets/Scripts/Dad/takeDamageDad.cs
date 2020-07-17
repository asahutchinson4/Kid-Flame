using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamageDad : MonoBehaviour
{
    public characterHealth health;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            health.ReduceHealth(100f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
