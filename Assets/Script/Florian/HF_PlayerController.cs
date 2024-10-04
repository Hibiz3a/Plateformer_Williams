using System.Collections;
using UnityEngine;

public class HF_PlayerController : MonoBehaviour
{
    Vector2 StartPos;
    Vector2 Dir;
    private float Horizontal;
    private float Vertical;
    [SerializeField] private float Speed;

    [SerializeField] Rigidbody2D Rb;
    [SerializeField] Transform Transform;
    [SerializeField] TrailRenderer TrailRenderer;
    [SerializeField] ParticleSystem PS;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Dir = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Dir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Dir = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        Rb.velocity = Dir * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HF_HitWall"))
        {
            PS.transform.position = Transform.position;
            PS.Play();
            TrailRenderer.emitting = false;
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HF_HitButton1"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color (97f/255f, 97f/255f, 97f/255f);
            DestroyDoor1();
        }
        if (collision.gameObject.CompareTag("HF_HitButton2"))
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(97f / 255f, 97f / 255f, 97f / 255f);
            DestroyDoor2();
        }

    }

    private void Respawn()
    {
        transform.position = StartPos;
        Dir = Vector2.zero;
        StartCoroutine(EmittingTrail());
    }
    IEnumerator EmittingTrail()
    {
        yield return new WaitForSeconds(0.5f);
        TrailRenderer.emitting = true;
    }

    private void DestroyDoor1()
    {
        Destroy(GameObject.FindWithTag("HF_Door1"));
    }
    private void DestroyDoor2()
    {
        Destroy(GameObject.FindWithTag("HF_Door2"));
    }
}
