using UnityEngine;

public class S_Camera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    private float _offset = 2.0f;

    private void Update()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _player.transform.position.y + _offset, _camera.transform.position.z);
    }
}