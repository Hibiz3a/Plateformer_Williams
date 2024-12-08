using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float upAndDownSpeed;
    [SerializeField] private float swimingSpeed;

    [SerializeField] private float minCamX;
    [SerializeField] private float maxCamX;

    private Rigidbody2D rb;
    private Transform selfTransform;
    private Transform camTransform;

    private bool isSwimingVerticaly;

    private Vector2 direction;
    private Vector2 nextPosition;
    private Vector3 nextCamPosition;
    private Vector2 nextVelocity;

    private PlayerInputs playerInputs;
    private InputAction moveInputs;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
        moveInputs = playerInputs.Player.Movements;
    }

    private void OnEnable()
    {
        moveInputs.Enable();
    }

    private void OnDisable()
    {
        moveInputs.Disable();
    }

    void Start()
    {
        moveInputs.performed += Movements;
        moveInputs.canceled += Movements;
        rb = GetComponent<Rigidbody2D>();
        selfTransform = transform;
        camTransform = transform.parent;
    }


    void Update()
    {
        MovementsInX();
        MovementsInY();

        if (rb.velocity.y < 0f && !isSwimingVerticaly)
        {
            nextVelocity.Set(rb.velocity.x, -(upAndDownSpeed / 2f));
            rb.velocity = nextVelocity;
        }
    }

    private void Movements(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    #region MovemntsInX

    private void MovementsInX()
    {
        if (direction.x == 0) { return; }

        if (direction.x < 0)
        {
            if (!(camTransform.position.x <= minCamX) && camTransform.position.x >= selfTransform.position.x)
            {
                CameraDeplacementsInX(-1);
            }
            else
            {
                CharacterDeplacementsInX(-1);
            }
            return;
        }

        if (!(camTransform.position.x >= maxCamX) && camTransform.position.x <= selfTransform.position.x)
        {
            CameraDeplacementsInX(1);
        }
        else
        {
            CharacterDeplacementsInX(1);
        }
    }

    private void CameraDeplacementsInX(int dir)
    {
        nextCamPosition.Set(camTransform.position.x + (dir * swimingSpeed) * Time.deltaTime, camTransform.position.y, -10);
        camTransform.position = nextCamPosition;
    }

    private void CharacterDeplacementsInX(int dir)
    {
        nextPosition.Set(selfTransform.position.x + (dir * swimingSpeed) * Time.deltaTime, selfTransform.position.y);
        transform.position = nextPosition;
    }

    #endregion

    #region MovementsInY

    private void MovementsInY()
    {
        if (direction.y == 0)
        {
            isSwimingVerticaly = false;
            return;
        }

        isSwimingVerticaly = true;
        if (direction.y > 0)
        {
            ChangeVelocityInY(1);
            return;
        }

        ChangeVelocityInY(-1);
    }

    private void ChangeVelocityInY(int dir)
    {
        nextVelocity.Set(rb.velocity.x, dir * upAndDownSpeed);
        rb.velocity = nextVelocity;
    }

    #endregion
}
