using UnityEngine;

public class DMCheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<DMPlayerController>().SetSpawn(transform);
        }
    }
}
