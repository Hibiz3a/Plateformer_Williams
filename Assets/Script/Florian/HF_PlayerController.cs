using UnityEngine;

public class HF_PlayerController : MonoBehaviour
{
    Vector2 StartPos;
    Vector2 Dir;
    private float Horizontal;
    private float Vertical;
    [SerializeField] private float Speed;

    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Transform Transform;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
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
            Respawn();
            Debug.Log("!!!!");
        }
    }

    private void Respawn()
    {
        transform.position = StartPos;
        // couper la derni�re direction de mouvement
        Dir = Vector2.zero;
    }
}
