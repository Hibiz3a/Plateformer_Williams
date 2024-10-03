using UnityEngine;

namespace DD
{
    public class DD_CameraController : MonoBehaviour
    {
        [Header("Player Reference")]
        [SerializeField] private Transform player;

        [Header("Camera")]
        [SerializeField] private float speedTransition = 2;
        [SerializeField] private Transform cameraPlayer;
        [SerializeField] private Transform cameraPlatform;

        [Header("Offset")]
        [SerializeField] float offsetPlayerCamera;
        [SerializeField] float offsetPlatformCamera;

        void LateUpdate()
        {
            UpdateCamera(cameraPlayer, player, offsetPlayerCamera, speedTransition);
            UpdateCamera(cameraPlatform, player, offsetPlatformCamera, speedTransition);
        }

        private void UpdateCamera(Transform from, Transform to, float offset, float t)
        {
            Vector3 targetPosition = new Vector3(from.position.x, to.position.y + offset, from.position.z);
            from.position = Vector3.Lerp(from.position, targetPosition, t * Time.deltaTime);
        }
    }
}