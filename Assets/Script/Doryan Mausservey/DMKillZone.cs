using UnityEngine;

public class DMKillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<DMPlayerController>().death();
        }
    }
}
