using UnityEngine;

namespace DD
{
    public class DD_PlayerTeleport : MonoBehaviour
    {
        private GameObject currentTeleporter;
        private DD_PlayerController playerReference;

        private bool particuleEnable = false;

        private void Awake()
        {
            playerReference = GetComponent<DD_PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Teleporter"))
            {
                currentTeleporter = collision.gameObject;
                if (Vector2.Distance(transform.position, currentTeleporter.transform.position) > 0.4f)
                {
                    transform.position = currentTeleporter.
                        GetComponent<DD_TeleporterController>().
                        GetDestination();

                    playerReference.IsBouncePad = true;
                    particuleEnable = false;
                    if (!playerReference.ParticuleTrail.isPlaying)
                        playerReference.ParticuleTrail.Play();
                }
            }

            if (collision.gameObject.CompareTag("IsGround") && playerReference.IsTeleporting)
            {
                playerReference.IsTeleporting = false;
                playerReference.ParticuleTrail.Stop();
                particuleEnable = false;
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