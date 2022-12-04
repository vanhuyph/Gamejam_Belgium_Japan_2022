using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private Inventory inventory;
    private float blackOrbsjump;
    private float vertical;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius;

    Animator animator;
    
    private bool isAtEnd = false;
    
    public void SetAtEnd()
    {
        isAtEnd = true;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAtEnd)
        {
            inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
            horizontal = Input.GetAxisRaw("Horizontal");
            blackOrbsjump = inventory.GetBlackOrbRate()*2;
            //Debug.Log("orbsjump = " + blackOrbsjump.ToString());
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                float jump = jumpingPower + blackOrbsjump;
                //Debug.Log("jump = " + jump.ToString());
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower + blackOrbsjump);
            }
            
            if (IsGrounded())
            {
                animator.SetBool("isJump", false);
            }
            else
            {
                animator.SetBool("isJump", true);
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
        else
        {
            horizontal = 0.0f;
            animator.SetFloat("WalkSpeed", horizontal);
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("walkSpeed", Mathf.Abs(horizontal));
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
        if (Mathf.Abs(horizontal) > 0.01f && IsGrounded())
        {
            AudioManager.instance.Play("Walk");
        }
        else
        {
            AudioManager.instance.Stop("Walk");
        }
    
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}