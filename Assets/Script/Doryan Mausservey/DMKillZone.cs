using UnityEngine;

public class DMKillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("i died");
            collision.GetComponent<DMPlayerController>().death();
        }
    }
}
