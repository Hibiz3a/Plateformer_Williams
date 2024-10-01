using UnityEngine;

public class DW_Jump_Systeme : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _jumpNumber = 4;
    [SerializeField] private float _jumpForce;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpNumber > 0)
        {
            _rb.velocity += Vector2.up * _jumpForce;
            _jumpNumber--;
        }
    }
}
