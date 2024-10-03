using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private readonly float BallVelocity=5;
    private Rigidbody2D BallRB;
    Vector2 FwdDir;
    

    void Start()
    {
        FwdDir = -transform.up;
        Vector2 norm= FwdDir*BallVelocity;
        BallRB = GetComponent<Rigidbody2D>();
        BallRB.AddForce(norm,ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            BallRB.AddForce(new Vector2(-1f, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            BallRB.AddForce(new Vector2(1f, 0));
        }       
    }
    private void FixedUpdate()
    {
        if (BallRB.velocity.y < 3 && BallRB.velocity.y>=0)
        {
            BallRB.velocity = new Vector2(BallRB.velocity.x, 3);
        }
        else if(BallRB.velocity.y > -3 && BallRB.velocity.y < 0)
        {
            BallRB.velocity = new Vector2(BallRB.velocity.x, -3);
        }
    }



    private void OnCollisionEnter2D(Collision2D _collision)
    {
        ContactPoint2D contact = _collision.GetContact(0);
        Vector3 newDirection = Vector2.Reflect(FwdDir, contact.normal);
        FwdDir =newDirection.normalized;
        BallRB.AddForce(FwdDir * BallVelocity, ForceMode2D.Impulse);
    }
    
    
}
