using UnityEngine;

public class BD_Death : MonoBehaviour
{
    [SerializeField]
    private Transform RespawnPoint;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Player"))
        {
            Rigidbody2D Rigidbody = _collision.GetComponent<Rigidbody2D>();
            Rigidbody.velocity = Vector3.down;
            _collision.transform.position = RespawnPoint.position;
        }
    }
}
