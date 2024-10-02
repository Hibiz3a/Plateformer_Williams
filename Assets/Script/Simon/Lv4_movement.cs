using UnityEngine;

public class Lv4_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRB;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private bool _isGrounded;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, _jumpForce * Time.deltaTime);
        }
        _myRB.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed * Time.deltaTime, _myRB.velocity.y);
    }
}
