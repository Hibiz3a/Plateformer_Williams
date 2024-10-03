using UnityEngine;

public class MG_Player : MonoBehaviour
{
    private float MoveSpeed = 5f;

    private Rigidbody2D rb;
    public bool IsOnFirstPlatform = false;

    private bool IsGrounded;
    public Transform FeetPos;
    public float CheckRadius;
    public float JumpForce;
    public LayerMask WhatIsGround;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool IsJumping;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float _moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_moveX * MoveSpeed, rb.velocity.y);
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, WhatIsGround);

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
            JumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * JumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && IsJumping)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else { IsJumping = false; }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.collider.CompareTag("Floor"))
        {
            if (_collision.collider.name == "platform")
            {
              IsOnFirstPlatform = true;
            }
        }
    }
}
