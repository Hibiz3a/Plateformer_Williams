using System;
using UnityEngine;

public class DD_BouncePad : MonoBehaviour
{
    [SerializeField] private float bounceForce = 25f;

    public void Jump(Rigidbody2D rb)
    {
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }
}