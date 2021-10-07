using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anmt;

    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anmt = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anmt.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anmt.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anmt.SetBool("Run", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anmt.SetBool("Jump", true);
            }
            else
            {
                if (doubleJump)
                {
                rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anmt.SetBool("Jump", false);
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
