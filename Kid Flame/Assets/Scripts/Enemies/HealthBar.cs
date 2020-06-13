using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private SpriteRenderer renderer;
    public EnemyHealth health;
    public FireFighterHealth fireHealth;

    private float barSize = 1f;
    private float fireBarSize = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        renderer = bar.Find("BarSprite").GetComponent<SpriteRenderer>();
        SetColor(Color.green);
    }

    public void Update()
    {
        fireBarSize = fireHealth.FireGetNormalizedHealth();
        SetSize(fireBarSize);
        if (fireBarSize < 0.3f)
        {
            SetColor(Color.red);
        }

        if (fireHealth.FirecurrentHealth == 0)
        {
            Destroy(this.gameObject);
        }

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
