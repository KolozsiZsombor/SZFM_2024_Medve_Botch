using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float playerHeight;
    public bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        float speed = 10f;

        Move(horizontalInput, speed);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, -Vector2.up, distance: math.INFINITY);

        if (hit && hit.distance < 1.1f)
        {
            isGrounded = true;
        }
        else { isGrounded = false; }



    }

    void Move(float horizontalInput, float speed)
    {
        Vector2 moveVelocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

}
