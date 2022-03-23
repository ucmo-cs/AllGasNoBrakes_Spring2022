using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    Rigidbody2D rb;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 5.0f;

    
    public int amtOfJumps = 1;

    public float groundCheckRadius;

    public Transform groundCheck;
    public LayerMask whatIsGround;

    private int amtOfJumpsLeft;
    private bool isGrounded;
    private bool canJump;
   
    
    // Enforce Movement Rulesets:
    // (i.e.: No-Infinite-Jumping, Allow-Wall-Jumping, Running, Dash, etc;)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        amtOfJumpsLeft = amtOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCanAJump();
        Jump();
        DetectMoveInput();
    }

    private void FixedUpdate()
    {
        //DetectMoveInput();
        CheckSurroundings();
    }
   
    private void CheckSurroundings()
    { // Handle checks for the "Ground" and "Wall" layers
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); // requires a point, radius, and layermask.
    }

    private void CheckIfCanAJump()
    {
        if(isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            amtOfJumpsLeft = amtOfJumps;
        }

        if(amtOfJumpsLeft <= 0)
        {
            canJump = false;
        } else { canJump = true; }
    }

    public void DetectMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * walkSpeed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
        Jump(); 
    }

    public void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");
        if (jump && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            amtOfJumpsLeft--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    // Exception Handling for GetComponent<>();
    /*private object GetComponent<T>()
    {
        throw new NotImplementedException();
    }*/
}