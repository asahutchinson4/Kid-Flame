using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

/*
 * Class for karmameter of the HUD.
 */
public class karmaMeter : MonoBehaviour {

    private const float MAX_BAD = -174;
    private const float MAX_GOOD = 174;

    private Transform needleTransform;

    private float moralMax;
    public static float moral;
    private float fireOldVal;
    private float localOldVal;
    private float fireCount;

    /*
     * Start is called before the first frame update.
     * Selts old values to zero.
     */
    void Start()
    {
        localOldVal = 0;
        fireOldVal = 0;
    }

    /*
     * Finds needle gameobject and sets moral to zero and
     * moralMax to 200.
     */
    void Awake()
    {
        needleTransform = transform.Find("needle");

        moral = 0f;
        moralMax = 200f;
    }

    /*
     * Update is called once per frame.
     * If dad dies then moral will be increased 
     * by 175. If a firefighter is killed then moral is
     * increased by 10 and if a local is killed then
     * moral is increased by 21 (Sums are multiplied by
     * Time.deltaTime * 4.0 to make the needle move with
     * time quickly). Moral will never surpass its max.
     */
    void Update()
    {
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

    /*
     * Getter for needle.
     */
    private float GetSpeedRotation()
    {
        float totalAngleSize = MAX_GOOD - MAX_BAD;

        float moralNormalized = moral / moralMax;

        return MAX_GOOD - moralNormalized * totalAngleSize;
    }

    /*
     * Waits for waitTime to allow engine
     * to see the change in value for fireCounter.
     */
    IEnumerator WaitForSecFire(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        fireOldVal = takeDamageFireFighter.fireCounter;
    }

    /*
    * Waits for waitTime to allow engine
    * to see the change in value for localCounter.
    */
    IEnumerator WaitForSecLocal(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        localOldVal = takeDamage.localCounter;
    }
}
