using UnityEngine;
using UnityEngine.EventSystems;

public class BD_Player : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private float Power = 10f;

    [SerializeField]
    private float MaxPower = 10f;

    private Vector2 MousePosition;
    private Rigidbody2D RigidBody;

    private bool IsGrounded = false;

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnDrag(PointerEventData _eventData)
    {
        //Set New Position Of The Mouse
        //Debug.Log("Drag");
    }

    public void OnPointerUp(PointerEventData _eventData)
    {
        if (!IsGrounded && RigidBody.velocity != Vector2.zero)
        {
            return;
        }

        //Calculate And Launch Player
        Vector2 Velocity = new Vector2(
            MousePosition.x - _eventData.position.x, 
            MousePosition.y - _eventData.position.y
        ) * Power / 1000;

        float SignX = Mathf.Sign(Velocity.x);
        float SignY = Mathf.Sign(Velocity.y);

        Vector2 VelocityCapped = new Vector2(
            Mathf.Clamp(Mathf.Abs(Velocity.x), MaxPower * -Mathf.Abs(Velocity.normalized.x), MaxPower * Mathf.Abs(Velocity.normalized.x)) * SignX,
            Mathf.Clamp(Mathf.Abs(Velocity.y), MaxPower * -Mathf.Abs(Velocity.normalized.y), MaxPower * Mathf.Abs(Velocity.normalized.y)) * SignY
        );

        RigidBody.velocity = VelocityCapped;
    }

    public void OnPointerDown(PointerEventData _eventData)
    {
        //Set Initial Position Of The Mouse
        MousePosition = _eventData.position;
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
    }
}
