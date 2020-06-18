using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "characterHealth", menuName = "Data/characterHealth", order = 1)]
    public class characterHealth : ScriptableObject
    {
        public EnemyHealth health;
        public FireFighterHealth fireHealth;


    public float GetNormalizedHealth()
    {
        return health.normalizedHealth;
        return fireHealth.FirenormalizedHealth;
    }

    //Reduces current health by amount. Minimum health is zero.
    public void ReduceHealth(float amount)
    {
        health.currentHealth -= amount;
        if (health.currentHealth < 0)
        {
            health.currentHealth = 0;
        }
        health.normalizedHealth = health.currentHealth / health.totalHealth;

    }

    //Reduces current health by amount. Minimum health is zero.
    public void FireReduceHealth(float amount)
    {
        fire.FirecurrentHealth -= amount;
        if (fireHealth.FirecurrentHealth < 0)
        {
            fireHealth.FirecurrentHealth = 0;
        }
        fireHealth.FirenormalizedHealth = fireHealth.FirecurrentHealth / fireHealth.FiretotalHealth;

    }
}

    

