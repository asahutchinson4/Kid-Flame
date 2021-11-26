using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Allows camera to follow kidflame.
*/
public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform targetToFollow;

    /*
     * Update is called once per frame.
     * Sets boundaries to where the camera will go
     * and clamps camera to player.
     */
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, -25f, 465f),
            transform.position.y,
            transform.position.z);
    }
}
