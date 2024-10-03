using UnityEditor;
using UnityEngine;

public class DW_Jump_Systeme : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _jumpNumber = 3;
    [SerializeField] private float _jumpForce;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpNumber > 0)
        {
            _rb.velocity += Vector2.up * _jumpForce;
            _jumpNumber--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _jumpNumber = 3;
    }
}
