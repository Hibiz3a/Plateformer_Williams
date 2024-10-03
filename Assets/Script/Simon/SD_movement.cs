using Unity.VisualScripting;
using UnityEngine;

public class SD_movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private BoxCollider2D Collider;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;
    [SerializeField] private GameObject BoxPrefab;
    [SerializeField] private int BoxLimit;
    private bool IsGrounded = false;
    private bool IsHoldingBox = false;
    private Vector3 RayCastOffset;
    private Vector3 BoxOffset;
    private CardinalDirections BoxDirection = CardinalDirections.Right;
    public int CurrentBoxNumber = 0;

    private void Start()
    {
        RayCastOffset = new Vector3(0, Collider.size.y, 0);
        BoxOffset = new Vector3(Collider.size.x, 0, 0);
    }

    private void Update()
    {
        FallCheck();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded)
            {
                RB.velocity = new Vector2(RB.velocity.x, JumpForce * Time.fixedDeltaTime);
            }
        }
        RB.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed * Time.fixedDeltaTime, RB.velocity.y);
        if (Input.GetMouseButtonDown(0) && !IsHoldingBox)
        {
            CreateBox();
        }
        CheckIsGrounded();
        StateHandler();
    }

    private void CheckIsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(Collider.transform.position - RayCastOffset, Vector2.down, Collider.size.y/2);
        if (hit.collider != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void CreateBox()
    {
        GameObject newBox;
        switch (BoxDirection)
        {
            case CardinalDirections.Right:
                BoxOffset = new Vector3(Collider.size.x, 0, 0);
                break;
            case CardinalDirections.Left:
                BoxOffset = new Vector3(-Collider.size.x, 0, 0);
                break;
            case CardinalDirections.Up:
                BoxOffset = new Vector3(0, Collider.size.y, 0);
                break;
            case CardinalDirections.Down:
                BoxOffset = new Vector3(0, -Collider.size.y, 0);
                break;
            default:
                BoxOffset = new Vector3(Collider.size.x, 0, 0);
                break;
        }
        if (CurrentBoxNumber < BoxLimit)
        {
            newBox = Instantiate(BoxPrefab, Collider.transform.position - BoxOffset, Quaternion.identity);
            newBox.GetComponent<SD_BoxBehaviour>().Init(this);
            CurrentBoxNumber++;
        }
    }

    private void StateHandler()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            BoxDirection = CardinalDirections.Left;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            BoxDirection = CardinalDirections.Right;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            BoxDirection = CardinalDirections.Down;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            BoxDirection = CardinalDirections.Up;
        }
        else
        {
            BoxDirection = CardinalDirections.Right;
        }
        if (Input.GetMouseButtonDown(0))
        {
            IsHoldingBox = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsHoldingBox = false;
        }
    }

    private void FallCheck()
    {
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(-8, 5, 0);
        }
    }

    enum CardinalDirections
    {
        Up,
        Down,
        Left,
        Right
    }
}
