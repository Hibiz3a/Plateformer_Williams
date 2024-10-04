using UnityEngine;

namespace DD
{
    public class DD_TeleporterController : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        public Vector3 GetDestination()
        {
            return destination.position;
        }
    }
}