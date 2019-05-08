using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed =100;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField]
    private CapsuleCollider2D playerCollider;

    [SerializeField]
    private GameObject firePoint;

    bool facingRight = true;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    protected override void ComputeVelocity()
    {
        
        // set move vector to zero
        Vector2 move = Vector2.zero;

        // move player left or right from inouts A/D or left/right arrows
        move.x = Input.GetAxis("Horizontal");

       
        //  Jumping. Check if player tries to jump from grounded state 
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            // Sets player animation to jump 
            animator.SetTrigger("jump");

        }

        // release jump force when jump button is released
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        // Flipping sprite to face camera, this doesnt actually manipulate the sprite at all just flips the player objects x axis scale
        // get the difference of player to mouse positions
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Check to see it mouse has moved from one side of plyer to the other and if so reverse to scale of x axis
        if (mousePos.x >= 0 && !facingRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
            //Changes direction of bullet trajectory 
            firePoint.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.forward);
            facingRight = true;
          

        }
        else if (mousePos.x < 0 && facingRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1);
            //Changes direction of bullet trajectory 
            firePoint.transform.localRotation = Quaternion.AngleAxis(180f, Vector3.forward);
            facingRight = false;
            
        }

        // Set the Animator Speed variable to players horizontal speed switches run animation
        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        

    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
            this.transform.parent = collision.transform;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
            this.transform.parent = null;
    }
    */


}