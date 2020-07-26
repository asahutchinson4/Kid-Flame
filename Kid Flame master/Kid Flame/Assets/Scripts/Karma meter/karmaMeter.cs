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
    private static float moral;
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
        //moral += 15f * Time.deltaTime;
        if (takeDamageDad.dadCounter == 1)
        {
            moral += 175 * Time.deltaTime;
        }

        if (takeDamageFireFighter.fireCounter > fireOldVal)
        {
            moral += 10f * Time.deltaTime;
            StartCoroutine("WaitForSecFire");
            UnityEngine.Debug.Log("Moral = " + moral);
        }

        if (takeDamage.localCounter > localOldVal)
        {
            moral += 25f * Time.deltaTime;
            StartCoroutine("WaitForSecLocal");
            UnityEngine.Debug.Log("Moral = " + moral);
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

    IEnumerator WaitForSecFire()
    {
        yield return new WaitForSeconds(1);
        fireOldVal = takeDamageFireFighter.fireCounter;
    } 
    
    IEnumerator WaitForSecLocal()
    {
        yield return new WaitForSeconds(1);
        localOldVal = takeDamage.localCounter;
    }
}
