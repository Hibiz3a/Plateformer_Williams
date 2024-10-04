using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BD_Player : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private float Power = 10f;

    [SerializeField]
    private float MaxPower = 10f;

    private Vector2 MousePosition;
    private Rigidbody2D RigidBody;

    [SerializeField]
    private bool IsGrounded = false;

    [SerializeField]
    private RectMask2D Mask;

    [SerializeField]
    private GameObject Indicator;

    [SerializeField]
    private GameObject IndicatorAngle;

    private void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        Debug.Log(RigidBody);
    }

    public void OnDrag(PointerEventData _eventData)

    {
        UpdateIndicator(_eventData);
    }

    public void UpdateIndicator(PointerEventData _eventData)
    {
        //Calculate And Show Indicator
        Vector2 Velocity = new Vector2(
            MousePosition.x - _eventData.position.x,
            MousePosition.y - _eventData.position.y
        ) * Power / 1000;

        if (Velocity.magnitude > 0)
        {
            Indicator.SetActive(true);

            float SignX = Mathf.Sign(Velocity.x);
            float SignY = Mathf.Sign(Velocity.y);

            Vector2 VelocityCapped = new Vector2(
                Mathf.Clamp(Mathf.Abs(Velocity.x), MaxPower * -Mathf.Abs(Velocity.normalized.x), MaxPower * Mathf.Abs(Velocity.normalized.x)) * SignX,
                Mathf.Clamp(Mathf.Abs(Velocity.y), MaxPower * -Mathf.Abs(Velocity.normalized.y), MaxPower * Mathf.Abs(Velocity.normalized.y)) * SignY
            );

            Mask.padding = new Vector4(0, 0, 1 - VelocityCapped.magnitude / 6, 0);

            IndicatorAngle.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan(VelocityCapped.y / VelocityCapped.x) * 180/(Mathf.PI));
            if (Mathf.Sign(VelocityCapped.x) >= 0)
            {
                IndicatorAngle.transform.rotation = Quaternion.Euler(0, 0, IndicatorAngle.transform.rotation.eulerAngles.z + 180);
            }
            IndicatorAngle.transform.rotation = Quaternion.Euler(0, 0, IndicatorAngle.transform.rotation.eulerAngles.z - 180);
        }
    }

    public void OnPointerUp(PointerEventData _eventData)
    {

        Indicator.SetActive(false);
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

        UpdateIndicator(_eventData);
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
