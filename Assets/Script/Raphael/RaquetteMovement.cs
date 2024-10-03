using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteMovement : MonoBehaviour
{
    //[SerializeField] GameObject m_raquette;
    [SerializeField] Rigidbody2D m_raquetteRB;
    private float m_RaquetteVelocity=-4;

    private void Start()
    {
        m_raquetteRB.velocity = new Vector2(m_RaquetteVelocity, 0);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (!_collision.gameObject.CompareTag("Player"))
            m_RaquetteVelocity=-m_RaquetteVelocity;
            m_raquetteRB.velocity= new Vector2(m_RaquetteVelocity, 0);
    }
}
