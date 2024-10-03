using UnityEngine;

public class NrmPlayerMovement : MonoBehaviour {

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _jumpForce = 10f;

    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _groundCheckRadius = 0.2f;

    Rigidbody2D _body;
    bool _isGrounded =true;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float moveInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(moveInput * _moveSpeed, _body.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _groundLayer);

        if (_isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))){
            _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
            _isGrounded = false;
        }
    }

}
