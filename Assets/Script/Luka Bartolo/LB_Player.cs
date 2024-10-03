using UnityEngine;

public class LB_Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float MouvementSpeed = 10f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddForce(Vector2.left * MouvementSpeed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddForce(Vector2.right * MouvementSpeed);
        }
    }
}
