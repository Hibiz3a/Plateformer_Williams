using UnityEngine;

public class DMPlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody2D RB2D;
    [SerializeField] private bool GroundCheck;
    [SerializeField] private GameObject Corpse;
    private Vector3 SpawnPoint;
    private void Awake()
    {
        SetSpawn(transform);
    }

    void Update()
    {
        RB2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, RB2D.velocity.y);
        if (Input.GetKey(KeyCode.Space) && GroundCheck)
        {
            GroundCheck = false;
            RB2D.velocity = new Vector2(RB2D.velocity.x, JumpForce);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GroundCheck = true;
    }

    public void SetSpawn(Transform transform)
    {
        SpawnPoint = transform.position;
    }

    public void death()
    {
        if (transform.position != SpawnPoint)
        {
            Instantiate(Corpse, transform.position, transform.rotation);
        }
        RB2D.velocity = Vector2.zero;
        transform.position = SpawnPoint;
    }
}
