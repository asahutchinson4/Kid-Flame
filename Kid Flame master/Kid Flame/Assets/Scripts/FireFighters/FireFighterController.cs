using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

/*
 * This script controls the firefighter's movement and checkers.
 */
public class FireFighterController : MonoBehaviour
{
    private enum State
    {
        Moving
    }

    public float interval;
    float nextShot = 0.0f;

    public characterHealth healthData;
    public GameObject WaterPrefab;
    public Transform sprayPoint;

    waterBall waterScript;

    private State currentState;

    [SerializeField]
    private float
        groundCheckDistance,
        wallCheckDistance,
        carCheckDistance,
        kidCheckDistance,
        localCheckDistance,
        fireManCheckDistance,
        movementSpeed;

    [SerializeField]
    private Transform
        groundCheck,
        wallCheck,
        carCheck,
        localCheck,
        fireManCheck,
        kidCheck;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private LayerMask whatIsKidFlame;

    [SerializeField]
    private LayerMask whatIsLocal;

    [SerializeField]
    private LayerMask whatIsFireMan;

    public int
        facingDirection;

    private Vector2 movement;

    private bool
        groundDetected,
        wallDetected,
        localDetected,
        fireManDetected,
        carDetected;

    public bool kidDetected;

    private GameObject fireMan;
    private Rigidbody2D fireManRb;
    private Animator fireManAnim;
    public Rigidbody2D waterRb;


    public float speed;
 
    /*
     * Start is called before the first frame update.
     * Finds firefighter gameobject and gets rigidbody
     * and animator components. Sets facing direction
     * to the right.
     */

    private void Start()
    {
        fireMan = this.gameObject;
        fireManRb = fireMan.GetComponent<Rigidbody2D>();
        fireManAnim = fireMan.GetComponent<Animator>();

        facingDirection = 1;

        waterScript = WaterPrefab.GetComponent<waterBall>();
        waterRb = WaterPrefab.GetComponent<Rigidbody2D>();

        waterScript.shooting = new Vector2(speed * facingDirection, 0f);
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
     * Ground, wall, car and kid detecters.
     * If kidflame is detected then the 
     * firefighter will use stop moving
     * and then fire water projectiles.
     * Timer is added and speed interval
     * is adjustable. Else if ground, wall
     * or car is detected then he will turn
     * around. If not any then he continues.
     */
    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        carDetected = Physics2D.Raycast(carCheck.position, transform.right, carCheckDistance, whatIsGround);
        kidDetected = Physics2D.Raycast(kidCheck.position, transform.right, kidCheckDistance, whatIsKidFlame);
        localDetected = Physics2D.Raycast(localCheck.position, transform.right, localCheckDistance, whatIsLocal);
        fireManDetected = Physics2D.Raycast(fireManCheck.position, transform.right, fireManCheckDistance, whatIsFireMan);

        if (kidDetected)
        {
            
            stop();

            if (Time.time >= nextShot && facingDirection == 1)
            {
                nextShot = Time.time + interval;
                sprayWater();
            }

            if (Time.time >= nextShot && facingDirection == -1)
            {
                nextShot = Time.time + interval;
                sprayWaterLeft();
            }
        }

        else if (!groundDetected || wallDetected || carDetected || localDetected || localDetected || fireManDetected)
        {
            flip();
        }
        else
        {
            movement.Set(movementSpeed * facingDirection, fireManRb.velocity.y);
            fireManRb.velocity = movement;
        }
    }

    /*
     * Shoots water projectiles
     */
    private void sprayWater()
    {
        Instantiate(WaterPrefab, sprayPoint.position, sprayPoint.rotation);
        waterScript.shooting.Set(speed, 0f);
        waterRb.velocity = waterScript.shooting;
    }

    private void sprayWaterLeft()
    {
        Instantiate(WaterPrefab, sprayPoint.position, sprayPoint.rotation);
        waterScript.shooting.Set(speed * -1, 0f);
        waterRb.velocity = waterScript.shooting;
    }

    /*
     * Changes facing direction and rotates firefighter
     * 180 degrees.
     */
    private void flip()
    {
        facingDirection *= -1;
        fireMan.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    /*
     * Stops firefighter from moving
     */
    private void stop()
    {
        movement.Set(movementSpeed * 0f, fireManRb.velocity.y);
        fireManRb.velocity = movement;
    }

    /*
     * Draws line used for detection
     */
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawLine(carCheck.position, new Vector2(carCheck.position.x + carCheckDistance, carCheck.position.y));
        Gizmos.DrawLine(kidCheck.position, new Vector2(kidCheck.position.x + kidCheckDistance, kidCheck.position.y));
        Gizmos.DrawLine(localCheck.position, new Vector2(localCheck.position.x + localCheckDistance, localCheck.position.y));
        Gizmos.DrawLine(fireManCheck.position, new Vector2(fireManCheck.position.x + fireManCheckDistance, fireManCheck.position.y));
    }
}
