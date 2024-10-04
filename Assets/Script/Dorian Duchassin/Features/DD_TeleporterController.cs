using UnityEngine;

namespace DD
{
    public class DD_TeleporterController : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        public Transform GetDestination()
        {
            return destination;
        }
    }
}