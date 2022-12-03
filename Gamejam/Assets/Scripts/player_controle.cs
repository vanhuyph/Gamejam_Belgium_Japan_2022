using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controle : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private Inventory inventory;
    private float blackOrbsjump;
    private float blackOrbsrate;
    private float vertical;
    private bool isLadder;
    private bool isClimbing;
    
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Update()
    {
        inventory= GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        horizontal = Input.GetAxisRaw("Horizontal");
        blackOrbsrate = inventory.GetBlackOrbRate();
        if (blackOrbsrate <= 1 && 0.5 < blackOrbsrate)
        {
            blackOrbsjump = blackOrbsrate * 2;
        }
        else
        {
            blackOrbsjump = 1;
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * blackOrbsjump);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        if (isLadder)
        {
            vertical = Input.GetAxisRaw("Vertical");
            if (Mathf.Abs(vertical) > 0)
            {
                isClimbing = true;
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (isClimbing)
        {
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4.0f;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}