using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private SpriteRenderer renderer;
    public characterHealth health;
    public FireFighterController fire;
    private static int face;

    private float barSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        renderer = bar.Find("BarSprite").GetComponent<SpriteRenderer>();
        SetColor(Color.green);

        face = FireFighterController.facingDirection;
    }

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
