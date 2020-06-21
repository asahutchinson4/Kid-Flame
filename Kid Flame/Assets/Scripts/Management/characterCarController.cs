using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCarController : MonoBehaviour
{
    public HealthBar1 healthBar;
    public characterHealth healthData;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.health = healthData;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthData.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            healthData.ReduceHealth(5);
        }
    }

}
