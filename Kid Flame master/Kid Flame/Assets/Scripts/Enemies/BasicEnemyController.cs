using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
 * This script controls the local's movement and checkers.
 */
public class BasicEnemyController : MonoBehaviour
{

   private enum State
    {
        Moving,
        Dead
    }
    
    public characterHealth healthData;
    
    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        carCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck,
        carCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    private int
        facingDirection;
        
    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected,
        carDetected;

    private GameObject alive;
    private Rigidbody2D aliveRb;
    private Animator aliveAnim;




    /*
     * Start is called before the first frame update.
     * Finds alive gameobject and gets rigidbody
     * and animator components. Sets facing direction
     * to the right.
     */
    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();


        facingDirection = 1;

    }

    /*
     * Update is called once per frame.
     * Just updates state to moving.
     */
    private void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
        }

    }

    /*
     * Ground, wall and car detecters. If local
     * detects any of these then he will flip
     * and start heading the other direction.
     * If not any then he continues.
     */
    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        carDetected = Physics2D.Raycast(carCheck.position, transform.right, carCheckDistance, whatIsGround);

        if(!groundDetected || wallDetected || carDetected)
        {
            flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, aliveRb.velocity.y);
            aliveRb.velocity = movement;
        }
    }

    /*
     * Changes facing direction and rotates local
     * 180 degrees.
     */
    private void flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    /*
     * Draws line used for detection
     */
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(carCheck.position, new Vector2(carCheck.position.x + carCheckDistance, carCheck.position.y));
    }
}
