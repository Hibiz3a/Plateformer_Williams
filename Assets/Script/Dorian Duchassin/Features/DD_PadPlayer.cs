using UnityEngine;

namespace DD
{
    public class DD_PadPlayer : MonoBehaviour
    {
        private GameObject currentBouncePad;
        private DD_PlayerController playerReference;

        private void Start()
        {
            playerReference = GetComponent<DD_PlayerController>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BouncePad"))
            {
                currentBouncePad = collision.gameObject;

                currentBouncePad.GetComponent<DD_BouncePad>().Jump(playerReference.Rb);
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