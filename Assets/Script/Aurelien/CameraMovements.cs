using TMPro;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] float posXMin;
    [SerializeField] float posXMax;

    private Transform _trasform;

    private void Start()
    {
        _trasform = GetComponent<Transform>();
    }


    public void MoveCamera(Transform playerTransform)
    {
        if(_trasform.position.x > posXMin && _trasform.position.x < posXMax)
        {
            transform.position = new Vector2(playerTransform.position.x, _trasform.position.y);
        }
    }
}
