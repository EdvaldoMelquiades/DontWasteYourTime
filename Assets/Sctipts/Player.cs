using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    private Rigidbody2D rigidBody2d;
    private Animator animator;
    private CircleCollider2D circleCollider2D;
    public float moveSpeed;
    public float jumpForce;
    public float moveInput;
    public bool canDoubleJump;
    private Transform playerPosition;
    private Transform spawnPointPosition;

    private void Awake ()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        playerPosition = GetComponent<Transform>();
        spawnPointPosition = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    private void Update ()
    {
        MovementAnimation();

        // Handle player movement
        moveInput = Input.GetAxis("Horizontal");
        rigidBody2d.velocity = new Vector2(moveInput * moveSpeed, rigidBody2d.velocity.y);

        // Set the double jump variable
        if (IsGrounded())
        {
            canDoubleJump = true;
        }
        
        // Handle player Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
    }

    private void MovementAnimation ()
    {
        if(Input.GetAxis("Horizontal") > 0f)
        {
            animator.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            animator.SetBool("Run", false);
        }
    }

    // Move this part to theirs respective GameObjects scripts
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            PlayerRespawn();
        }

        if(collision.gameObject.tag == "Saw")
        {
            PlayerRespawn();
        }
    }

    private bool IsGrounded ()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.41f, Color.red);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 0.41f, groundLayerMask);
        return raycastHit2D.collider != null;
    }

    private void PlayerRespawn()
    {
        playerPosition.position = new Vector2(spawnPointPosition.position.x, spawnPointPosition.position.y);
    }
}