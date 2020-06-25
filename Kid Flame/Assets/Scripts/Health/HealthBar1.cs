using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
    private Transform bar;
    private static SpriteRenderer renderer;
    public characterHealth health;
    public FireFighterController fire;
    private static int direction;


    private float barSize = 1f;
    private float fireBarSize = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        renderer = bar.Find("BarSprite").GetComponent<SpriteRenderer>();
        SetColor(Color.green);

        direction = FireFighterController.facingDirection;

        //renderer.flipX = false;
    }

    public void Update()
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

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color newColor)
    {
        renderer.color = newColor;
    }
}
