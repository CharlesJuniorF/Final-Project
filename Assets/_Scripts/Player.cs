using System.Collections;
using System.Net.Http.Headers;
using UnityEngine;

/*
    This script provides jumping and movement in Unity 3D - Gatsby
*/

public class Player : MonoBehaviour
{
    // Camera Rotation
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    // Jumping
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f; // Multiplies gravity when falling down
    public float ascendMultiplier = 2f; // Multiplies gravity for ascending to peak of jump
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;

    //reset position if the player glitches
    public Vector3 resetPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = Camera.main.transform;

        // Set the raycast to be slightly beneath the player's feet
        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        // Hides the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        if (!GameManager._gameOver)
        {
            if(!GameManager._paused) RotateCamera();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        // Checking when we're on the ground and keeping track of our ground check delay
        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }


        if (GameManager._paused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(GameManager._gameOver || GameManager._youWin)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
        ApplyJumpPhysics();
        if (transform.position.y < -8f || transform.position.y > 60f)
        {
            ResetPos();
        }
    }

    void MovePlayer()
    {

        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        Vector3 targetVelocity = movement * MoveSpeed;

        // Apply movement to the Rigidbody
        Vector3 velocity = rb.velocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.velocity = velocity;

        // If we aren't moving and are on the ground, stop velocity so we don't slide
        if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    void Jump()
    {
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // Initial burst for the jump
    }

    void ApplyJumpPhysics()
    {
        if (rb.velocity.y < 0)
        {
            // Falling: Apply fall multiplier to make descent faster
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        } // Rising
        else if (rb.velocity.y > 0)
        {
            // Rising: Change multiplier to make player reach peak of jump faster
            rb.velocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("BossBrain"))
        {
            Vector3 bossPos = collision.transform.position;

            // Direction away from boss (X/Z only)
            Vector3 directionAway = gameObject.transform.position - bossPos;
            directionAway.y = 0.0f;

            directionAway = SendAway(directionAway);

            float horizontalForce = 120f;

            rb.velocity = Vector3.zero;

            rb.AddForce((directionAway * horizontalForce), ForceMode.Impulse);

            GameManager.SubtractBossHealth();
        }
    }

    private Vector3 SendAway(Vector3 directionAway)
    {
        int myRandNum = Random.Range(0, 3);

        if (myRandNum == 1)
        {
            directionAway += new Vector3(Random.Range(2, 3), 0, Random.Range(-3, -2));
        }
        else if (myRandNum == 2)
        {
            directionAway += new Vector3(Random.Range(-3, -2), 0, Random.Range(2, 3));
        }
        else if (myRandNum == 3)
        {
            directionAway += new Vector3(Random.Range(2, 3), 0, Random.Range(2, 3));
        }
        else
        {
            directionAway += new Vector3(Random.Range(-3, -2), 0, Random.Range(-3, -2));
        }

        directionAway.y = 0.0f;

        return directionAway;
    }

    public void ResetPos()
    {
        transform.position = resetPoint;
    }
}