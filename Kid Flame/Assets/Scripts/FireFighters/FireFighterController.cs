using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class FireFighterController : MonoBehaviour
{
    private enum State
    {
        Moving
    }

    public characterHealth healthData;
    public HealthBar1 healthBar;
    public GameObject WaterPrefab;
    public Transform sprayPoint;

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        carCheckDistance,
        kidCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck,
        carCheck,
        kidCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private LayerMask whatIsKidFlame;

    public int
        facingDirection;
    //private int
        //facingDirection;


    private Vector2 movement;
 
    private bool
        groundDetected,
        wallDetected,
        carDetected,
        kidDetected;

    private GameObject fireMan;
    private Rigidbody2D fireManRb;
    private Animator fireManAnim;

    private void Start()
    {
        fireMan = transform.Find("FireFighter").gameObject;
        fireManRb = fireMan.GetComponent<Rigidbody2D>();
        fireManAnim = fireMan.GetComponent<Animator>();

        facingDirection = 1;

    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
        }
    }

    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        carDetected = Physics2D.Raycast(carCheck.position, transform.right, carCheckDistance, whatIsGround);
        kidDetected = Physics2D.Raycast(kidCheck.position, transform.right, kidCheckDistance, whatIsKidFlame);

        if (kidDetected)
        {
            stop();
            sprayWater();
        }

        else if (!groundDetected || wallDetected || carDetected)
        {
            flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, fireManRb.velocity.y);
            fireManRb.velocity = movement;
        }
    }

    private void sprayWater()
    {
       Instantiate(WaterPrefab, sprayPoint.position, sprayPoint.rotation);
    }

    private void flip()
    {
        facingDirection *= -1;
        fireMan.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void stop()
    {
        movement.Set(movementSpeed * 0f, fireManRb.velocity.y);
        fireManRb.velocity = movement;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(carCheck.position, new Vector2(carCheck.position.x + carCheckDistance, carCheck.position.y));
        Gizmos.DrawLine(kidCheck.position, new Vector2(kidCheck.position.x + kidCheckDistance, kidCheck.position.y));
    }
}
