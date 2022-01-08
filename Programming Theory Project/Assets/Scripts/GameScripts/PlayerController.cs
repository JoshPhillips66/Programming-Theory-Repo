using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody playerRb;
    private PlayerInput playerInput;
    private InputActions inputActions;
    private Vector2 moveInput;
    private float moveSpeed = 200f;

    private void Awake()
    {
        

        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        inputActions = new InputActions();
        inputActions.Default.Enable();

        inputActions.Default.Quit.performed += Quit_Performed;
        inputActions.Default.Jump.performed += Jump_Performed;
        inputActions.Default.Shoot.performed += Shoot_Performed;
        
    }

    void Update()
    {
        Move();

    }

    void Move()
    {
        //TODO: Need to set up good movement and rotation!!!!!
        moveInput = inputActions.Default.Move.ReadValue<Vector2>().normalized;
        playerRb.AddForce(new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed, ForceMode.Force);
    }

    void Quit_Performed(InputAction.CallbackContext context)
    {
        //Sends call to gameMager to Quit to the main menu
        //TODO: pause game and pullup menu to quit or resume
        gameManager.QuitGame();
    }

    void Jump_Performed(InputAction.CallbackContext context)
    {
        //Make player jump
    }

    void Shoot_Performed(InputAction.CallbackContext context)
    {
        //make player shoot
    }


}
