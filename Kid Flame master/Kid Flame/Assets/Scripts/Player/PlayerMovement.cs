using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used for kid flame's movement, ability to jump and
 * ability to shoot fireballs. Checks to see if he is touching
 * the ground.
 */
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public Transform player;
    public float moveSpeed = 3f;
    public float jumpVelocity = 60f;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2dGround;
    private BoxCollider2D boxCollider2dCloud;
    public GameObject FireballPrefab;
    public Transform firePoint;
    public characterHealth health;
    

    /*
     * Start is called before the first frame update.
     * Assigns rigidboyd and colliders.
     */
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2dCloud = transform.GetComponent<BoxCollider2D>();
        boxCollider2dGround = transform.GetComponent<BoxCollider2D>();

        health.currentHealth = 100;
        health.normalizedHealth = 1;
    }

    /*
     * Update is called once per frame.
     * Gives him his speed and checks to see if he is touching the ground.
     * If he is touching the ground then he can jump. If F is pressed then
     * he can shoot fireballs.
     */
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !ShowUI.inDialogBox)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            SoundManager.playJumpSound();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            shootFireball();
        } 
    }

    /*
     * Checks to see if kid flame is touching the ground. Used
     * for jumping. Ground includes the clouds and the ground.
     */
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2dGround = Physics2D.BoxCast(boxCollider2dGround.bounds.center, boxCollider2dGround.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2dGround.collider);
        return raycastHit2dGround.collider != null;

        RaycastHit2D raycastHit2dCloud = Physics2D.BoxCast(boxCollider2dCloud.bounds.center, boxCollider2dCloud.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2dCloud.collider);
        return raycastHit2dCloud.collider != null;
    }

    /*
     * Shoots fireballs.
     */
    public void shootFireball()
    {
        Instantiate(FireballPrefab, firePoint.position, firePoint.rotation);
    }
}
