﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


/*
 * For healthbar used above NPCs.
 */
public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private SpriteRenderer renderer;
    public characterHealth health;
    public FireFighterController fire;
    private static int face;
    private float barSize = 1f;

    /*
     * Start is called before the first frame update.
     * Assigning bar. Getting sprite renderer. Setting color of 
     * the bar to green and assigning reference to face.
     */
    void Start()
    {
        bar = transform.Find("Bar");
        renderer = bar.Find("BarSprite").GetComponent<SpriteRenderer>();
        SetColor(Color.green);

        face = FireFighterController.facingDirection;
    }

    /*
     * Update is called once per frame.
     * Assigning barsize. Setting bar size. If bar is below
     * 30% then it will change to the color red. If health 
     * reaches 0 then the firefighter will dissapear.
     */
    void Update()
    {
       
        barSize = health.GetNormalizedHealth();
        SetSize(barSize);
        if (barSize < 0.3f)
        {
            SetColor(Color.red);
        }
        
        if (health.currentHealth == 0)
        {
            Destroy(this.gameObject);
        }


        checkBar();
    }

    //In progress function
    private void checkBar()
    {
        if (face == 1)
        {
            
            UnityEngine.Debug.Log("faceright");
        }

        if (face == -1)
        {
            
            UnityEngine.Debug.Log("faceleft");
        }

        //if(direction == 1)
        //{
        //renderer.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}

        //if(direction == -1)
        //{
        // renderer.transform.localRotation = Quaternion.Euler(0, 180, 0);
        //}

        //if(renderer.flipX == true)
        //{
        //renderer.flipX = true;
        //}

    }

    /*
     * Setter for barsize
     */
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    /*
     * Setter for barcolor
     */
    public void SetColor(Color newColor)
    {
        renderer.color = newColor;
    }
}
