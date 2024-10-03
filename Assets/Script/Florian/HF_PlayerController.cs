using UnityEngine;

public class HF_PlayerController : MonoBehaviour
{
    Vector2 Dir;
    private float Horizontal;
    private float Vertical;
    [SerializeField] private float Speed;

    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Transform Transform;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            Dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            Dir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Dir = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = Dir * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HF_HitWall"))
        {


            Debug.Log("!!!!");
        }
    }
}
