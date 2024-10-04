using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKingControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveImput;
    private bool isCharging;
    [SerializeField] private GameObject sprite;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float jumpSpeedMultiplier;
    [SerializeField] private Vector2 boxSise;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

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
        
        if (isCharging)
        {
            sprite.transform.localScale = new Vector3(1.5f, 0.75f, 1f);
            sprite.transform.localPosition = new Vector3(0f, -0.3f, 0f);
        }

        if (Input.GetKeyDown("space") && IsGrounded())
        {
            isCharging = true;
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyUp("space") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * (jumpSpeedMultiplier*1.2f));
            rb.velocity = new Vector2(moveImput * walkSpeed, rb.velocity.y);
            isCharging = false;
            sprite.transform.localScale = Vector3.one;
            sprite.transform.localPosition = Vector3.zero;
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
