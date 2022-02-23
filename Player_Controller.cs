using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 5.0f;
  
    Rigidbody2D rb;
    // Enforce Movement Rulesets:
    // (i.e.: No-Infinite-Jumping, Allow-Wall-Jumping, Running, Dash, etc;)

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Jump();
        DetectMoveInput();
    }

    public void DetectMoveInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * walkSpeed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);   
    }

    public void Jump()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}