using Unity.VisualScripting;
using UnityEngine;

public class NrmPlayerMovement : MonoBehaviour {

    [SerializeField] float MoveSpeed = 5f;
    [SerializeField] float JumpForce = 5f;

    [SerializeField] LayerMask GroundLayer;
    [SerializeField] float GroundCheckDistance = 0.2f;
    [SerializeField] Vector2 CheckSize;
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

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, CheckSize, 0f, Vector2.down, GroundCheckDistance, GroundLayer);
        _isGrounded = hit.collider != null;

        if (_isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))){
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
