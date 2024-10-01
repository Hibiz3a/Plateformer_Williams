using UnityEngine;

namespace DD
{
    public class DD_PlayerController : MonoBehaviour
    {

        Rigidbody2D _rb;
        private float _horizontal;

        [SerializeField] private int sizeInPixel = 9;
        [SerializeField] private float movementSpeed = 2.0f;
        [SerializeField] private float powerJump = 10.0f;
        [SerializeField] private bool isGrounded = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            ResizeSpriteToPixels(sizeInPixel);
        }

        void Update()
        {
            _horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rb.AddForce(new Vector2(0, powerJump), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                ResizeSpriteToPixels(sizeInPixel);
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontal * movementSpeed, _rb.velocity.y);
        }

        private bool IsGrounded()
        {

            return isGrounded;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "IsGround")
                isGrounded = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "IsGround")
                isGrounded = false;
        }

        void ResizeSpriteToPixels(int nbPixel)
        {
            Camera cam = Camera.main;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            float screenHeightInPixels = Screen.height;
            float worldHeight = cam.orthographicSize * 2.0f;

            float spriteHeight = spriteRenderer.sprite.bounds.size.y;

            float pixelPerUnit = spriteRenderer.sprite.pixelsPerUnit;
            float targetWorldHeight = nbPixel / screenHeightInPixels * worldHeight;

            Vector3 newScale = transform.localScale;
            newScale.y = targetWorldHeight / spriteHeight;
            newScale.x = newScale.y;  
            transform.localScale = newScale;
        }
    }
}