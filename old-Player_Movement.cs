using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb; 
    public float walk_SpeedX = 1f; public float walk_SpeedY = 1f;
    public float jumpForce = 2f;
    // detect double jump permission:
    // jumping infinitely still needs fixed.
    bool isGrounded = false;
    public Transform IfGroundedCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // later can add different speeds if we want to:  
    // run speed ---------------------  // run if button pressed = shift

    // --- flipping player sprite to match direction you move ------
    // public float face_direction = ?;
    // private boolean flip_Player_sprite;    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {     
        detect_movement();
        jump();   
    }

    public void jump()
    {
        checkIfGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void checkIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(IfGroundedCheck.position, groundCheckRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    public void detect_movement()
    {
        // check for jump input.     
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        { // move player left.
            rb.velocity = new Vector2(-walk_SpeedX, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        { // move player right
            rb.velocity = new Vector2(walk_SpeedX, rb.velocity.y);
        }
        else // if not moving --> set x velocity to 0 and y velocity remains the same.
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }      
    }
}
