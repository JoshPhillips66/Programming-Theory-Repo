using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    public InputActions inputActions;
    public PlayerInput playerInput;
    Vector2 moveInput;

    public PlayerController playerController;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        inputActions = new InputActions();
        inputActions.Default.Enable();
        animator = GetComponent<Animator>();
        if (gameManager.gameOver == true) {
            inputActions.Default.Disable();
        }


    }

    private void Update()
    {

        moveInput = inputActions.Default.Move.ReadValue<Vector2>();
        CheckMovement();
        CheckButtons();

    }

    private void CheckMovement()
    {
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            animator.SetBool("isIdle", true);
        }
        if (moveInput.y > 0)
        {
            animator.SetBool("isMovingForward", true);
        } else
        {
            animator.SetBool("isMovingForward", false);
        }
        if (moveInput.y < 0)
        {
            animator.SetBool("isMovingBackward", true);
        } else
        {
            animator.SetBool("isMovingBackward",false);
        }
        if (moveInput.x > 0)
        {
            animator.SetBool("isMovingRight", true);
        }
        else
        {
            animator.SetBool("isMovingRight", false);
        }
        if (moveInput.x < 0)
        {
            animator.SetBool("isMovingLeft", true);
        }
        else
        {
            animator.SetBool("isMovingLeft", false);
        }
    }

    private void CheckButtons()
    {
        if (inputActions.Default.Jump.WasPressedThisFrame() && playerController.groundedPlayer)
        {
            animator.SetBool("isJumping", true);
        }
        if (inputActions.Default.Jump.WasReleasedThisFrame() && !inputActions.Default.Jump.WasPerformedThisFrame())
        {
            animator.SetBool("isJumping", false);
        }

        if (inputActions.Default.Shoot.WasPressedThisFrame())
        {
            animator.SetBool("isShooting", true);
        }
        if (inputActions.Default.Shoot.WasReleasedThisFrame() && !inputActions.Default.Jump.WasPerformedThisFrame())
        {
            animator.SetBool("isShooting", false);
        }
    }

}
