using UnityEngine;
using UnityEngine.UIElements;

public class MG_ObstacleManager : MonoBehaviour
{
    private float InitPos;
    private Vector2 BackupPos;
    public float MoveSpeed = 1.5f;
    [SerializeField] MG_Player PlayerSC;
    public bool ObstacleIsOnFinishPlatform = false;
    private void Start()
    {
        InitPos = transform.position.y;
        BackupPos = transform.position;
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
        if (_collision.CompareTag("Player"))
        {
            RestartLevels();
        }
    }

    private void RestartLevels()
    {
        PlayerSC.IsOnFirstPlatform = false;
        transform.position = BackupPos;
        PlayerSC.transform.position = PlayerSC.InitPos;
    }
}
