
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput inputManager;
    private InputAction jumpAction;

    private Rigidbody2D myBody;

    public float speed = 10f;
    public float jumpSpeed = 5f;
    private float minX = -2.5f;
    private float maxX = 2.5f;
    private bool onGround ;
    private bool jumping = false;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        jumpAction = inputManager.actions["Jump"];
        myBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
    }
    void Update()
    {
        GroundCheck();
        PlayerMove();
    }
    private void FixedUpdate()
    {
    }

    private void GroundCheck()    {
        onGround = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);
        if (onGround)
        {
            if (jumping)
            {
                jumping = false;
            }
        }
    }

   
    public void PlayerMove()
    {
        Debug.Log(inputManager.actions["Move"].type);
        Vector2 playerPosition = transform.position;
        //float h = context.ReadValue<Vector2>().x;
        float h = inputManager.actions["Move"].ReadValue<Vector2>().x;
        if (h > 0)
        {
            playerPosition.x += speed * Time.deltaTime;
        }
        else if (h < 0)
        {
            playerPosition.x -= speed * Time.deltaTime;
        }
        //// Restrict player to the game area
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        transform.position = playerPosition;
    }
    public void PlayerJump(InputAction.CallbackContext context)
    {
        if (onGround && !jumping)
        {
            onGround = false;
            jumping = true;
            myBody.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb")
        {
            GameplayController.instance.GameOver();
        }
    }
} // class end
