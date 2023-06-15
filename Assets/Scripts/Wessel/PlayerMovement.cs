using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Sprinting //
    public bool isMoving = false;
    public float sprintSpeed = 8.0f;

    // Movement speed //
    public float speed = 4.0f;
    public float gravity = -9.81f;

    // Check if player is grounded //
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Stamina Main //
    public float playerStamina = 100.0f;
    private float maxStamina;
    public bool hasRegenerated = true;
    public bool isSprinting = false;

    // Stamina Regen //
    public float staminaDrain = 30.0f;
    public float staminaRegen = 12.0f;

    // Stamina Bar //
    public StaminaBar staminaBar;

    void Start()
    {
        maxStamina = playerStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (!isSprinting)
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Sprint //

        if (Input.GetKeyDown(KeyCode.W))
        {
            isMoving = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isMoving && playerStamina > 0)
        {
            isSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            if (playerStamina < 0)
            {
                playerStamina = 0;
                isSprinting = false;
            }
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }

        else
        {
            isSprinting = false;
            if (playerStamina < maxStamina && hasRegenerated)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                if (playerStamina > maxStamina)
                {
                    playerStamina = maxStamina;
                }
            }
        }
        staminaBar.SetStamina(playerStamina);
    }
}
