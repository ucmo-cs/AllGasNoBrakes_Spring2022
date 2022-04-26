using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Animator anim;
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSprite;

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = GetComponent<SpriteRenderer>();

        isGrounded = true;
        amtOfJumpsLeft = amtOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //playerAnim.IdleAnimation();
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
        if (isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
            amtOfJumpsLeft = amtOfJumps;
        }

        if (amtOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else { canJump = true; }
    }

    public void DetectMoveInput()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float moveBy = moveInput * walkSpeed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
            if (moveInput < 0) { playerSprite.flipX = true; }
            else if (moveInput > 0) { playerSprite.flipX = false; }
        }

        /*if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            playerSprite.flipX = false;
            playerAnim.RunAnimaton();
        } 
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            playerSprite.flipX = true;
            playerAnim.RunAnimaton();
        }*/

        Jump();
    }

    public void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");
        if (jump && isGrounded)
        {
            anim.SetTrigger("takeOff");
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            amtOfJumpsLeft--;
        }

        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}