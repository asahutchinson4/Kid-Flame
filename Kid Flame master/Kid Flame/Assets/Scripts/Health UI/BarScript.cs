using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/*
 * Handles bar for Kid Flames health
 */
public class BarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private UnityEngine.UI.Image content;

    public characterHealth health;
    private float barSize = 1f;


    /*
     * Update is called once per frame. Changes 
     * healthbar's fill amount to how much
     * health kid flame has. If health bar is below
     * 40% then the filler will change colors to blue.
     */
    void Update()
    {
        barSize = health.GetNormalizedHealth();
        HandleBar(barSize);

        if(barSize < 0.4f)
        {
            ChangeColor(Color.blue);
        }
        if(barSize >= 0.4f)
        {
            ChangeColor(Color.red);
        }
    }

    /*
     * Assigns how filled up the healthbar is to
     * how much health kid flame has.
     */
    private void HandleBar(float sizeNormalized)
    {
        content.fillAmount = sizeNormalized;
    }

    /*
     * Changes healthbar filler to a color of your
     * choosing.
     */
    private void ChangeColor(Color newColor)
    {
        content.color = newColor;
    }
}
