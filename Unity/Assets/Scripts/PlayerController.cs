using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 40f;
    private bool isGrounded;
    public LayerMask jumpable;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Move(horizontalInput, moveSpeed);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, 0.5f, -Vector2.up, distance: math.INFINITY, jumpable);

        if (hit && hit.distance < 0.75f)
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
