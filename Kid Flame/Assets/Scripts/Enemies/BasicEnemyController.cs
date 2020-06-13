using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class BasicEnemyController : MonoBehaviour
{
   private enum State
    {
        Moving,
        Dead
    }
    
    public GameObject healthBar;
    public Transform barPoint;

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


    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRb = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();


        facingDirection = 1;

        carryHealthBar();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
        }

        healthBar.transform.position = barPoint.transform.position;
    }

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

    private void flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(carCheck.position, new Vector2(carCheck.position.x + carCheckDistance, carCheck.position.y));
    }

    public void carryHealthBar()
    {
        healthBar = Instantiate(healthBar, barPoint.position, barPoint.rotation);
    }
}
