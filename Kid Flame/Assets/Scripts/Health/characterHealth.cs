using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "characterHealth", menuName = "Data/characterHealth", order = 1)]
public class characterHealth : ScriptableObject
{
    public float currentHealth = 100f;
    public float totalHealth = 100f;
    public float normalizedHealth = 1f;

    public float GetNormalizedHealth()
    {
        return normalizedHealth;
        // This second return statement can never be executed. The method will exit at the first return.
        //return fireHealth.FirenormalizedHealth;
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



