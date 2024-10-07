using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;

public class MG_Player : MonoBehaviour
{
    [SerializeField] public MG_End end;
    [SerializeField] public MG_ObstacleManager obstacleManager;
    [SerializeField] public GameObject textIndic;
    public float MoveSpeed = 5f;
    public Vector3 InitPos;

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
        InitPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Destroy(textIndic, 1.5f);
    }

    private void FixedUpdate()
    {
        float _moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_moveX * PlayerSpeed(), rb.velocity.y);

    }

    private float PlayerSpeed()
    {
        float _initialSpeed = MoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return MoveSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            return _initialSpeed;
        }
        return MoveSpeed;
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
        if (_collision.collider.name == "platform")
        {
            IsOnFirstPlatform = true;
        }
        if(_collision.collider.name == "EndPlatform")
        {
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        end.PlayerIsOnEndPlatform = true;
        yield return new WaitForSeconds(2.0f);
        IsOnFirstPlatform = false;
        yield return null;
    }   
}
