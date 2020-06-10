using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2dGround;
    private BoxCollider2D boxCollider2dCloud;
    public GameObject FireballPrefab;
    public Transform firePoint;
    

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2dCloud = transform.GetComponent<BoxCollider2D>();
        boxCollider2dGround = transform.GetComponent<BoxCollider2D>();
    }

 


    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 60f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            shootFireball();
        }

        
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2dGround = Physics2D.BoxCast(boxCollider2dGround.bounds.center, boxCollider2dGround.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2dGround.collider);
        return raycastHit2dGround.collider != null;

        RaycastHit2D raycastHit2dCloud = Physics2D.BoxCast(boxCollider2dCloud.bounds.center, boxCollider2dCloud.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2dCloud.collider);
        return raycastHit2dCloud.collider != null;
    }



    public void shootFireball()
    {
        Instantiate(FireballPrefab, firePoint.position, firePoint.rotation);
    }

   
}
