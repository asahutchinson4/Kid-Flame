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

    // Start is called before the first frame update
    void Awake()
    {
        needleTransform = transform.Find("needle");

        moral = 0f;
        moralMax = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        moral += 30f * Time.deltaTime;
        
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
