using UnityEngine;

public class PlayerControllerGP : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Rigidbody2D RB2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        Vector2 Movement = new Vector2(movehorizontal,RB2D.velocity.y);
        RB2D.AddForce(Movement);
    }
}
