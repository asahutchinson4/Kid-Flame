using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHealth", menuName = "Data/Health", order = 1)]
public class EnemyHealth : ScriptableObject
{
    public float currentHealth = 100f;
    public float totalHealth = 100f;
    private float normalizedHealth = 1f;


    public float GetNormalizedHealth()
    {
        return normalizedHealth;
    }

    //Reduces current health by amount. Minimum health is zero.
    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        normalizedHealth = currentHealth / totalHealth;

    }
}

