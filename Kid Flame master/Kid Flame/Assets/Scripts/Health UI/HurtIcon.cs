using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Class for blue Kid Flame icon on the
 * HUD health bar.
 */
public class HurtIcon : MonoBehaviour
{
    public characterHealth health;

    public Image hurtIcon;

    /*
     * Start is called before the first frame update.
     * Inenables hurt icon.
     */
    void Start()
    {
        hurtIcon.enabled = false;
    }

    /*
     * Update is called once per frame.
     * if Kid Flame's health is under 40% then
     * the hurt icon will be activated else it
     * will be disabled.
     */
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
