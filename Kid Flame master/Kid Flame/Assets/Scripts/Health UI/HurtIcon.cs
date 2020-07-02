using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtIcon : MonoBehaviour
{
    public characterHealth health;

    public Image hurtIcon;

    // Start is called before the first frame update
    void Start()
    {
        hurtIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.normalizedHealth < .4f)
        {
            hurtIcon.enabled = true;
        }
        else
        {
            hurtIcon.enabled = false;
        }
    }
}
