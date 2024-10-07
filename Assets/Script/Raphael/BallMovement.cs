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
                pow += Time.deltaTime*2;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                BallRB.AddForce(new Vector2((pow), 0));
                pow += Time.deltaTime*2;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                pow = 4;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                pow = 4;
            }
        }     
    }
    private void FixedUpdate()
    {
        if (BallRB.velocity.x <= -5) 
        {
            BallRB.velocity = new Vector2(-5, BallRB.velocity.y);
        }
        if (BallRB.velocity.x >= 5)
        {
            BallRB.velocity = new Vector2(5, BallRB.velocity.y);
        }
        //if(Mathf.Abs(BallRB.velocity.x) <= 0.1f && Mathf.Abs(BallRB.velocity.y) <= 0.1f)
        //{
          //  transform.position = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
        //}
    }

}
