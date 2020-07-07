using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Explosion particle for when a car gets hit by
 * fireball.
 */
public class explosionScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject explosionPrefab;
    public characterHealth health;

    /*
     * If fireball collides with car then it blows up.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(this.gameObject);

            health.GainHealth(15f);
        }
    }
}
