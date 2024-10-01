using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DW_PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _speedMax;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (_rb.velocity.x > 0)
                _rb.velocity = new Vector2(0, _rb.velocity.y);
            if (_rb.velocity.x > -_speedMax)
            {
                _rb.AddForce(Vector2.left * _walkSpeed * Time.deltaTime, ForceMode2D.Force);
                if (_rb.velocity.x < -_speedMax)
                    _rb.velocity = new Vector2(-_speedMax, _rb.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (_rb.velocity.x < 0)
                _rb.velocity = new Vector2(0, _rb.velocity.y);

            if (_rb.velocity.x < _speedMax)
            {
                _rb.AddForce(Vector2.right * _walkSpeed * Time.deltaTime, ForceMode2D.Force);
                if (_rb.velocity.x > _speedMax)
                    _rb.velocity = new Vector2(_speedMax, _rb.velocity.y);
            }
        }
    }
}
