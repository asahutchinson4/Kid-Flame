using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCharacterHealth : MonoBehaviour
{
    private characterHealth healthConfiguration;
    private float currentHealth;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = healthConfiguration.currentHealth;
        maxHealth = healthConfiguration.totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
