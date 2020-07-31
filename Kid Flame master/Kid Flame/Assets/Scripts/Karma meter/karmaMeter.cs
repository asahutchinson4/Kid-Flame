using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class karmaMeter : MonoBehaviour {

    private const float MAX_BAD = -174;
    private const float MAX_GOOD = 174;

    private Transform needleTransform;

    private float moralMax;
    public static float moral;
    private float fireOldVal;
    private float localOldVal;
    private float fireCount;

    // Start is called before the first frame update
    void Start()
    {
        localOldVal = 0;
        fireOldVal = 0;
    }

    void Awake()
    {
        needleTransform = transform.Find("needle");

        moral = 0f;
        moralMax = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log("Moral: " + moral);

        if (takeDamageDad.dadCounter == 1)
        {
            moral += 175 * Time.deltaTime;
        }

        if (takeDamageFireFighter.fireCounter > fireOldVal)
        {
            moral += 10f * (Time.deltaTime * 4.0f);
            StartCoroutine(WaitForSecFire(0.3f));
        }

        if (takeDamage.localCounter > localOldVal)
        {
            moral += 21f * (Time.deltaTime * 4.0f);
            StartCoroutine(WaitForSecLocal(0.2f));
        }
      
        if(moral > moralMax)
        {
            moral = moralMax;
        }

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = MAX_GOOD - MAX_BAD;

        float moralNormalized = moral / moralMax;

        return MAX_GOOD - moralNormalized * totalAngleSize;
    }

    IEnumerator WaitForSecFire(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        fireOldVal = takeDamageFireFighter.fireCounter;
    } 
    
    IEnumerator WaitForSecLocal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        localOldVal = takeDamage.localCounter;
    }
}
