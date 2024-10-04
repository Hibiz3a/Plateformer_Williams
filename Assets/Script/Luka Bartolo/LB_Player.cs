using UnityEngine;

public class LB_Player : MonoBehaviour
{
    [SerializeField] private ParticleSystem _speedParticles;
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
        SpeedParticles();
    }

    void SpeedParticles()
    {
        var _particlesMainSettings = _speedParticles.main;
        if (_rb.velocity.y <= 20)
        {
            _speedParticles.Stop();
            _particlesMainSettings.startLifetime = 0.2f;
        }
        else
        {
            _speedParticles.Play();
            _particlesMainSettings.startLifetime = _rb.velocity.y / 100;
        }
    }
}
