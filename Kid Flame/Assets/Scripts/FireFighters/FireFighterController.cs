using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FireFighterController : MonoBehaviour
{
    private enum State
    {
        Moving
    }

    public float interval;
    float nextShot = 0.0f;

    public characterHealth healthData;
    public HealthBar1 healthBar;
    public GameObject WaterPrefab;
    public Transform sprayPoint;
    public waterBall water;

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

    
    //private int
        //facingDirection;

    public int
        facingDirection;

    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected,
        carDetected;

    public bool kidDetected;

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

            if (Time.time >= nextShot && facingDirection == 1)
            {
                nextShot = Time.time + interval;
                sprayWaterRight();
            }

            else if (Time.time >= nextShot && facingDirection == -1)
            {
                nextShot = Time.time + interval;
                sprayWaterLeft();
            }
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

    private void sprayWaterRight()
    {
       Instantiate(WaterPrefab, sprayPoint.position, sprayPoint.rotation);
       //water.rb.velocity = new Vector2(water.speed, 0);
    }

    private void sprayWaterLeft()
    {
        Instantiate(WaterPrefab, sprayPoint.position, sprayPoint.rotation);
        //water.rb.velocity = new Vector2(water.speed * -1, 0);
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
