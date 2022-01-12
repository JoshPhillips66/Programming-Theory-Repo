using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    private CharacterController controller;
    private PlayerInput playerInput;
    public InputActions inputActions;
    private Vector2 moveInput;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    private Transform cameraTransform;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform barrelTransform;
    [SerializeField] private Transform bulletParentTransform;

    private float bulletMissDistance = 20f;

    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float rotationSpeed = 20f;
    private float playerHealth = 5f;
    private float knockbackSpeed = 6f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;

        inputActions = new InputActions();
        inputActions.Default.Enable();

        inputActions.Default.Quit.performed += Quit_Performed;
        inputActions.Default.Jump.performed += Jump_Performed;
        inputActions.Default.Shoot.performed += Shoot_Performed;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (!gameManager.gameOver)
        {
            Move();
            if (IsDead())
            {
                Debug.Log("The Game is OVER!!!");
                gameManager.GameOver();
            }
        }

    }

    private bool IsDead()
    {
        if (playerHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TakeHit(float damage, Vector3 enemyPosition)
    {
        playerHealth -= damage;
        gameManager.UpdateHealth(playerHealth);
        Vector3 knockBackDirection = (transform.position - enemyPosition).normalized;
        controller.Move(new Vector3(knockBackDirection.x * knockbackSpeed, .5f, knockBackDirection.z * knockbackSpeed));
    }

    void Move()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        moveInput = inputActions.Default.Move.ReadValue<Vector2>();

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        Quaternion rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }


    void Quit_Performed(InputAction.CallbackContext context)
    {
        inputActions.Default.Disable();
        gameManager.QuitGame();
    }

    void Jump_Performed(InputAction.CallbackContext context)
    {
        if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        }
    }

    void Shoot_Performed(InputAction.CallbackContext context)
    {

        RaycastHit hit;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParentTransform);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
        }
        else
        {
            bulletController.target = cameraTransform.position + cameraTransform.forward * bulletMissDistance;
            bulletController.hit = false;
        }
    }
}
