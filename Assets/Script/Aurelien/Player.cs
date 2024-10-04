using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float upAndDownSpeed;
    [SerializeField] private float swimingSpeed;

    [SerializeField] private float minCamX;
    [SerializeField] private float maxCamX;
    
    private Rigidbody2D rb;
    private Transform _transform;
    private Transform camTransform;

    private bool isSwimingUpOrDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = transform;
        camTransform = transform.parent;
    }

    
    void Update()
    {
        Deplacement();

        if(rb.velocity.y < 0f && !isSwimingUpOrDown)
            rb.velocity = new Vector2(rb.velocity.x, -(upAndDownSpeed / 2f));
    }


    private void Deplacement()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(!(camTransform.position.x <= minCamX) && camTransform.position.x >= _transform.position.x)
                camTransform.position = new Vector3(camTransform.position.x - swimingSpeed * Time.deltaTime, camTransform.position.y, -10);
            else
                transform.position = new Vector2(_transform.position.x - swimingSpeed * Time.deltaTime, _transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!(camTransform.position.x >= maxCamX) && camTransform.position.x <= _transform.position.x)
                camTransform.position = new Vector3(camTransform.position.x + swimingSpeed * Time.deltaTime, camTransform.position.y, -10);
            else
                transform.position = new Vector2(_transform.position.x + swimingSpeed * Time.deltaTime, _transform.position.y);
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
