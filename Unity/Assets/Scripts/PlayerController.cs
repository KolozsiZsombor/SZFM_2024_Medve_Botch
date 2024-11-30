using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 40f;
    private bool isGrounded;
    private bool onPlatform;
    public LayerMask jumpable;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Move(horizontalInput, moveSpeed);

        if ((isGrounded || onPlatform) && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (onPlatform && Input.GetButtonDown("Down"))
        {
            MoveThroughPlatform();
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, 0.5f, -Vector2.up, distance: math.INFINITY, jumpable);

        double roundedHitDistance = Math.Round(hit.distance, 2);


        if (hit && (roundedHitDistance == 0.51))
        {
            isGrounded = true;

            if (hit.collider.CompareTag("Platform"))
            {
                onPlatform = true;
            }
        }
        else
        {
            isGrounded = false;
            onPlatform = false;
        }
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

    void MoveThroughPlatform()
    {
        Vector2 curPos = rb.position;
        rb.position = new Vector2(curPos.x, curPos.y - 2f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            if (other.GetComponent<AutomaticDoor>().Moving == false)
            {
                other.GetComponent<AutomaticDoor>().Moving = true;
            }
        }
    }

}
