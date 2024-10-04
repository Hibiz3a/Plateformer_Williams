using UnityEngine;

namespace DD
{
    public class DD_PadPlayer : MonoBehaviour
    {
        private GameObject currentBouncePad;
        private DD_PlayerController playerReference;

        private bool particuleEnable = false;

        private void Awake()
        {
            playerReference = GetComponent<DD_PlayerController>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BouncePad"))
            {
                playerReference.IsBouncePad = true;

                currentBouncePad = collision.gameObject;
                currentBouncePad.GetComponent<DD_BouncePad>().Jump(playerReference.Rb);

                particuleEnable = true;
                if (!playerReference.ParticuleTrail.isPlaying)
                    playerReference.ParticuleTrail.Play();
            }

            if (collision.gameObject.CompareTag("IsGround") && playerReference.IsBouncePad)
            {
                playerReference.IsBouncePad = false;
                playerReference.ParticuleTrail.Stop();
                particuleEnable = false;
            }
        }



        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BouncePad"))
            {
                if (collision.gameObject == currentBouncePad)
                {
                    currentBouncePad = null;
                }
            }
        }
    }
}