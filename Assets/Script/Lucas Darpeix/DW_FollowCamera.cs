using UnityEngine;

public class DW_FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private Transform _transform;
    private void Start()
    {
        _transform = transform;
    }
    void Update()
    {
        _camera.position = new Vector3(_camera.position.x, _transform.position.y, _camera.position.z);
    }
}
