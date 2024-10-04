using UnityEngine;

namespace DD
{
    public class DD_PlayerController : MonoBehaviour
    {

        private Rigidbody2D _rb;
        private float horizontalAxis;
        private float jumpAxis;


        [Header("Manager")]
        [SerializeField] private int sizeInPixel = 9;


        [Header("Player Settings")]
        [SerializeField] private float movementSpeed = 2.0f;
        [SerializeField] private float powerJump = 10.0f;
        private bool isGrounded = false;
        private bool isBouncePad = false;
        private bool isTeleporting = false;

        [Header("Particule Settings")]
        [SerializeField] private ParticleSystem particuleTrail;
        [SerializeField] private float idleThreshold = 2.0f; // Time after which objTrail is activated
        private float idleTime = 0f;
        private bool isMoving = false;
        

        public Rigidbody2D Rb {
            get => _rb;
            private set => _rb = value;
        }

        public ParticleSystem ParticuleTrail
        {
            get => particuleTrail;
            set => particuleTrail = value;
        }

        public bool IsBouncePad
        {
            get => isBouncePad;
            set => isBouncePad = value;
        }

        public bool IsTeleporting
        {
            get => isTeleporting;
            set => isTeleporting = value;
        }


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            ResizeSpriteToPixels(sizeInPixel);
        }

        private void Start()
        {
            if (particuleTrail.isPlaying)
                particuleTrail.Stop();
        }

        void Update()
        {
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            jumpAxis = Input.GetAxisRaw("Jump");

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                Rb.AddForce(new Vector2(0, powerJump), ForceMode2D.Impulse);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                ResizeSpriteToPixels(sizeInPixel);
            }

            CheckMovement();
        }

        private void FixedUpdate()
        {
            Rb.velocity = new Vector2(horizontalAxis * movementSpeed, Rb.velocity.y);
        }

        private bool IsGrounded()
        {

            return isGrounded;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("IsGround"))
                isGrounded = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("IsGround"))
                isGrounded = false;
        }


        private void CheckMovement()
        {
            if (isBouncePad)
                return;

            if (Mathf.Abs(horizontalAxis) > 0.01f || Mathf.Abs(jumpAxis) > 0.01f) // Player is moving
            {
                isMoving = true;
                idleTime = 0f;

                particuleTrail.Stop();
            }
            else 
            {
                if (isMoving) 
                {
                    isMoving = false;
                }
                idleTime += Time.deltaTime;

                if (idleTime >= idleThreshold)
                {
                    if (!particuleTrail.isPlaying)
                        particuleTrail.Play();
                }
            }
        }



        // TO Have the perfect pixel
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