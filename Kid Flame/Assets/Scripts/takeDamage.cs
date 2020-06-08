using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public EnemyHealth health;

    private void OnCollisionEnter2D(Collision2D other)
    {
        health.ReduceHealth(15f);
    }

    
}
