using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float upAndDownSpeed;
    [SerializeField] private float swimingSpeed;
    [SerializeField] CameraMovements cameraMovement;

    private Rigidbody2D rb;

    private bool isSwimingUpOrDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Deplacement();

        if(rb.velocity.y < 0f && !isSwimingUpOrDown)
            rb.velocity = new Vector2(rb.velocity.x, -(upAndDownSpeed / 2f));
    }


    private void Deplacement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - swimingSpeed * Time.deltaTime, transform.position.y);
            cameraMovement.MoveCamera(transform);
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + swimingSpeed * Time.deltaTime, transform.position.y);
            cameraMovement.MoveCamera(transform);
        }
        
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, upAndDownSpeed);
            isSwimingUpOrDown = true;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -(upAndDownSpeed));
            isSwimingUpOrDown = true;
        }
        else
        {
            isSwimingUpOrDown = false;
        }
    }

}
