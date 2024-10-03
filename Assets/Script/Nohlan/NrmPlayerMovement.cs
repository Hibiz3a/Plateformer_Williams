using UnityEngine;

public class NrmPlayerMovement : MonoBehaviour {

    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float JumpForce = 5f;

    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float GroundCheckRadius = 0.2f;
    [SerializeField] Vector2 StartPos;
    [SerializeField] GameObject Border;

    Rigidbody2D _body;
    bool _isGrounded =true;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float moveInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(moveInput * MoveSpeed, _body.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(transform.position, GroundCheckRadius, GroundLayer);

        if (_isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))){
            _body.velocity = new Vector2(_body.velocity.x, JumpForce);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject == Border){
            transform.position = StartPos;
        }
    }

}
