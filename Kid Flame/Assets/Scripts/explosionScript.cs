using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject explosionPrefab;


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(this.gameObject);
        }
    }
}
