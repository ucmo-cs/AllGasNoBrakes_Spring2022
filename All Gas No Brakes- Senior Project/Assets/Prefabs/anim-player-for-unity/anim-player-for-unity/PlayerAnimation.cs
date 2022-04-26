using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{ 
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void IdleAnimation()
    {
        anim.Play("Idle");
    }

    public void RunAnimaton()
    {
        anim.Play("Run");
    }

    public void JumpAnimation()
    {
        anim.Play("Jump");
    }

    public void LandJumpAnimation()
    {
        anim.Play("Land-Jump");
    }
}
