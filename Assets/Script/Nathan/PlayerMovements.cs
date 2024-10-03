using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody2D nathanrb;
    private bool isGrounded;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public LayerMask killLayer;
    public Transform groundCheck;
    public float moveSpeed = 2;

    void Start()
    {
        nathanrb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movements();
    }

    private void Movements()
    {
        isGroundedCheck();

        this.transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            nathanrb.velocity = new Vector2(nathanrb.velocity.x, 3.0f);
        }
    }

    private void isGroundedCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & killLayer) != 0)
        {
            SceneManager.LoadScene("Nathan_Plateformer");
        }
    }
}