using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Level;

    public bool OnGround = false;

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.transform.CompareTag("Thomas_Ground"))
        {
            Debug.Log(Collision);
            OnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            Level.GetComponent<LevelManager>().StopLevel();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            OnGround = false;
            GravityChange();
            print("saut");
        }
    }


    public void GravityChange()
    {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = this.gameObject.GetComponent<Rigidbody2D>().gravityScale * -1;
    }
}
