using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum PlayerState { Idle, Running, Airborne }

    public Animator animator;

    PlayerState state;
    bool stateComplete;

    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;

    //public float acceleration;
    public float maxXSpeed;
    public float jumpSpeed;

    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;
    float xInput;


    // Update is called once per frame
    void Update()
    {
        CheckInPut();
        HandleXMovement();
        HandleJump();

        if (stateComplete)
        {
            SelectState();
        }
        UpdateState();
    }

    void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    void SelectState()
    {
        stateComplete = false;

        if (grounded)
        {
            if (xInput == 0)
            {
                state = PlayerState.Idle;
                StartIdle();      
            } else {
                state = PlayerState.Running;
                StartRunning();
            }
        } else {
            state = PlayerState.Airborne;
            StartAirborne();
        }
    }

    void UpdateState()
    {
        switch (state) {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Running:
                UpdateRun();
                break;
            case PlayerState.Airborne:
                UpdateAirborne();
                break;
        }
    }

    void StartIdle()
    {
        animator.Play("Idle");
    }

    void StartRunning()
    {
        animator.Play("Run");
    }

    void StartAirborne()
    {
        animator.Play("Jump");
    }

    void UpdateIdle()
    {
        if (xInput != 0)
        {
            stateComplete = true;
        }
    }

    void UpdateRun()
    {
        if (!grounded || xInput == 0)
        {
            stateComplete = true;
        }
    }

    void UpdateAirborne()
    {
        if (grounded)
        {
            stateComplete = true;
        }
    }

    void CheckInPut()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void HandleXMovement()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            body.velocity = new Vector2(xInput * maxXSpeed, body.velocity.y);

            FaceInput();
        }
    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction()
    {
        if (grounded && xInput == 0 && body.velocity.y <=0)
        {
            body.velocity *= groundDecay;
        }
    }
}
