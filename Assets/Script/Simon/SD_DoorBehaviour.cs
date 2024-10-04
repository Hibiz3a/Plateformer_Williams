using UnityEngine;

public class SD_DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform MyTransform;
    private Vector3 OpenedScale = new Vector3(-1.5f, 0, 0);
    private Vector3 OpenedPosition = new Vector3(0, 1f, 0);

    public void OpenDoor()
    {
        MyTransform.position += OpenedPosition;
        MyTransform.localScale += OpenedScale;
    }

    public void CloseDoor()
    {
        MyTransform.position -= OpenedPosition;
        MyTransform.localScale -= OpenedScale;
    }
}
