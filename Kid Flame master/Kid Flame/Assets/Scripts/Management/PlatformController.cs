using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls movement and boundaries of moving platforms.
 */
public class PlatformController : MonoBehaviour
{
    float dirX, moveSpeed = 1f;
    bool moveRight = true;
    private float initialX;
    private float moveLimit = 4f;
    private float xLimit;
    private float negxLimit;

    /*
     * Start is called before the first frame update.
     * Assigns limits.
     */
    void Start()
    {
        initialX = transform.position.x;
        xLimit = initialX + moveLimit;
        negxLimit = initialX - moveLimit;
    }


    /*
     * Update is called once per frame.
     * Updates how far moving platforms can go before
     * they need to head the other direction.
     */
    void Update()
    {
        if (transform.position.x > xLimit)
            moveRight = false;
        
        if (transform.position.x < negxLimit)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

