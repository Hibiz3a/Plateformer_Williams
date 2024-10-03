using UnityEngine;

namespace DD
{
    public class DD_PlayerTeleport : MonoBehaviour
    {
        private GameObject currentTeleporter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Teleporter"))
            {
                currentTeleporter = collision.gameObject;
                if (Vector2.Distance(transform.position, currentTeleporter.transform.position) > 0.3f)
                {
                    transform.position = currentTeleporter.GetComponent<DD_TeleporterController>().GetDestination().position;
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Teleporter"))
            {
                if (collision.gameObject == currentTeleporter)
                {
                    currentTeleporter = null;
                }
            }
        }
    }
}