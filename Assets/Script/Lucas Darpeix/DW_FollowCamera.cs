using UnityEngine;

public class DW_FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private Transform _transform;
    private Vector2 _initPosition;
    private void Start()
    {
        _transform = transform;
        _initPosition = _transform.position;
    }
    void Update()
    {
        _camera.position = new Vector3(_camera.position.x, _transform.position.y, _camera.position.z);
    }

    public void ResetPlayer()
    {
        _transform.position = _initPosition;
    }
}
