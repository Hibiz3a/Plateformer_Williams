using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteMovement : MonoBehaviour
{
    //[SerializeField] GameObject m_raquette;
    [SerializeField] Rigidbody2D m_raquetteRB;
    private float m_RaquetteVelocity=-4;
    float timer = 0;
    public bool growned = false;

    private void Start()
    {
        m_raquetteRB.velocity = new Vector2(m_RaquetteVelocity, 0);
    }
    private void Update()
    {
        if (growned)
        {
            timer += Time.deltaTime;
            if (timer > 3) 
            {
                transform.localScale = new Vector3(4, 0.25f, 1);
                growned = false;
                timer = 0;
            }

        }
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (!_collision.gameObject.CompareTag("Player"))
            m_RaquetteVelocity=-m_RaquetteVelocity;
            m_raquetteRB.velocity= new Vector2(m_RaquetteVelocity, 0);
    }
}
