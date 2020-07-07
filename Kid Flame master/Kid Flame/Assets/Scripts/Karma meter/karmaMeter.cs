using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class karmaMeter : MonoBehaviour {

    private const float MAX_BAD = -174;
    private const float MAX_GOOD = 174;

    private Transform needleTransform;

    private float moralMax;
    private float moral;
    private float fireOldVal;
    private float localOldVal;
    private float fireCount;

    public takeDamageFireFighter fireman;

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

        if (takeDamageFireFighter.fireCounter > fireOldVal)
        {
            moral += 15f;
            fireOldVal = takeDamageFireFighter.fireCounter;
        }

        if (takeDamage.localCounter > localOldVal)
        {
            moral += 30f;
            localOldVal = takeDamage.localCounter;
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
}
