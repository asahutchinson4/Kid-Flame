using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireFighterHealth", menuName = "Data/FireHealth", order = 1)]
public class FireFighterHealth : ScriptableObject
{
    public float FirecurrentHealth = 100f;
    public float FiretotalHealth = 100f;
    public float FirenormalizedHealth = 1f;


    public float FireGetNormalizedHealth()
    {
        return FirenormalizedHealth;
    }

    //Reduces current health by amount. Minimum health is zero.
    public void FireReduceHealth(float amount)
    {
        FirecurrentHealth -= amount;
        if (FirecurrentHealth < 0)
        {
            FirecurrentHealth = 0;
        }
        FirenormalizedHealth = FirecurrentHealth / FiretotalHealth;

    }
}
