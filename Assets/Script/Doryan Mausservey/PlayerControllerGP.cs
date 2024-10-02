using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControllerGP : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody2D RB2D;
    [SerializeField] private bool GroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(transform.GetComponentInChildren<BoxCollider2D>() == true) {
        RB2D.position += new Vector2(Input.GetAxis("Horizontal")*Time.deltaTime*Speed,0);
        if (GroundCheck == true ) 
        {
                RB2D.position += new Vector2(0, Input.GetAxis("Jump") * Time.deltaTime * JumpForce);
        }
    }
}
