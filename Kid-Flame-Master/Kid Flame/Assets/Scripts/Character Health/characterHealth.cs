using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Base for all character health. All scriptable objects
 * for characters are derived from this script.
 */
[CreateAssetMenu(fileName = "characterHealth", menuName = "Data/characterHealth", order = 1)]
public class characterHealth : ScriptableObject
{
    public float currentHealth = 100f;
    public float totalHealth = 100f;
    public float normalizedHealth = 1f;

    /*
     * Getter for normalized health
     */
    public float GetNormalizedHealth()
    {
        return normalizedHealth;
        // Note from Dr. Branton: This second return statement can never be executed. The method will exit at the first return.
        //return fireHealth.FirenormalizedHealth;
    }

    /*
     * Reduces current health by amount. Minimum health is zero.
     */
    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        normalizedHealth = currentHealth / totalHealth;

    }

    /*
     * Adds to current health.
     */
    public void GainHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
        normalizedHealth = currentHealth / totalHealth;
    }
 
}



