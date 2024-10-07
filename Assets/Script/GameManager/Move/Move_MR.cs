using UnityEngine;

public class Move_MR : MonoBehaviour
{
    [SerializeField] private float speed = 0.001f;
    [SerializeField] private float jumpForce = 0.001f;
    public Rigidbody2D RB;
    private Vector2 currentVelocity;
    
    [SerializeField]
    private bool jump = false;
    private float smoothing = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float posx = Input.GetAxis("Horizontal") * speed / 5;
        float posy = Input.GetAxis("Vertical") * speed / 5;

        Vector2 targetVelecity = new Vector2(posx, RB.velocity.y);
        RB.velocity = Vector2.SmoothDamp(RB.velocity, targetVelecity, ref currentVelocity, smoothing);

        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            jump = true;
            RB.AddForce(new Vector2(posy, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(("Ground")))
        {
            jump = false;
        }
    }
}
