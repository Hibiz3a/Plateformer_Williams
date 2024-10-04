using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private readonly float BallVelocity=5;
    private Rigidbody2D BallRB;
    Vector2 FwdDir;
    [Range(1, 5)] private float pow=1;
    

    void Start()
    {
        FwdDir = transform.up;
        Vector2 norm= FwdDir*BallVelocity;
        BallRB = GetComponent<Rigidbody2D>();
        BallRB.AddForce(norm,ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            BallRB.simulated = true;
            Transform ControlsDisplay=transform.GetChild(0);
            ControlsDisplay.gameObject.SetActive(false);
        }
        if (BallRB.simulated)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                BallRB.AddForce(new Vector2(-(pow), 0));
                pow += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                BallRB.AddForce(new Vector2((pow), 0));
                pow += Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                pow = 1;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                pow = 1;
            }
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
        else if(BallRB.velocity.y < -6)
        {
            BallRB.velocity = new Vector2(BallRB.velocity.x, -6);
        }
        else if (BallRB.velocity.y > 6)
        {
            BallRB.velocity = new Vector2(BallRB.velocity.x, 6);
        }
        if (BallRB.velocity.x > 6)
        {
            BallRB.velocity = new Vector2(6, BallRB.velocity.y);
        }
        else if (BallRB.velocity.x <-6)
        {
            BallRB.velocity = new Vector2(-6, BallRB.velocity.y);
        }
        if (BallRB.velocity.magnitude ==0)
        {
            BallRB.velocity = new Vector2(0,-2);
        }
        if(Mathf.Abs(BallRB.velocity.x)<=0.1f && Mathf.Abs(BallRB.velocity.y) <= 0.1f)
        {
            BallRB.gameObject.transform.position += new Vector3(-0, -1);
        }
        if(Mathf.Abs(BallRB.velocity.x)<0.1f && Mathf.Abs(BallRB.velocity.y) < 0.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
        }
    }



    private void OnCollisionEnter2D(Collision2D _collision)
    {
        ContactPoint2D contact = _collision.GetContact(0);
        Vector3 newDirection = Vector2.Reflect(FwdDir, contact.normal);
        FwdDir =newDirection.normalized;
        BallRB.AddForce(Vector2.ClampMagnitude(FwdDir * BallVelocity,5), ForceMode2D.Impulse);
    }
    
    
}
