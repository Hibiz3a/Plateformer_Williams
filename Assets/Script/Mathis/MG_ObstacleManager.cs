using UnityEngine;

public class MG_ObstacleManager : MonoBehaviour
{
    private float InitPos;
    private float MoveSpeed = 1.5f;
    [SerializeField] MG_Player PlayerSC;
    private void Start()
    {
        InitPos = transform.position.y;
    }

    private void Update()
    {
        if (PlayerSC.IsOnFirstPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, InitPos++, 0), MoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        Destroy(_collision.gameObject);
    }
}
