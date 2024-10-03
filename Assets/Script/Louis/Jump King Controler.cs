using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKingControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveImput;
    private bool isCharging;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpSpeedMultiplier;
    [SerializeField] private Vector2 boxSise;
    [SerializeField] private float castDistance;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveImput = Input.GetAxisRaw("Horizontal");

        if (IsGrounded() && !isCharging)
        {
            rb.velocity = new Vector2(moveImput * walkSpeed, rb.velocity.y);
        }

        Jump();        
    }
    public void Jump()
    {
        if (isCharging && jumpSpeedMultiplier <= 0.7f)
        {
            jumpSpeedMultiplier += Time.deltaTime;
        }
        

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            isCharging = true;
        }
        if (Input.GetKeyUp("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * (jumpSpeedMultiplier*1.2f));
            rb.velocity = new Vector2(moveImput * walkSpeed, rb.velocity.y);
            isCharging = false;
            jumpSpeedMultiplier = 0f;
        }
    }

    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSise, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSise);
    }
}
