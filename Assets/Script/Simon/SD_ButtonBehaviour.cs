using UnityEngine;

public class SD_ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Transform MyTransform;
    [SerializeField] private SD_DoorBehaviour ConnectedDoor;
    private Vector3 PressedScale = new Vector3(0, -0.15f, 0);
    private Vector3 PressedPosition = new Vector3(0, -0.15f, 0);
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        MyTransform.position += PressedPosition;
        MyTransform.localScale += PressedScale;
        _collision.gameObject.transform.position += PressedPosition*2;
        ConnectedDoor.OpenDoor();
    }
    private void OnCollisionExit2D(Collision2D _collision)
    {
        MyTransform.position -= PressedPosition;
        MyTransform.localScale -= PressedScale;
        _collision.gameObject.transform.position -= PressedPosition * 2;
        ConnectedDoor.CloseDoor();
    }
}
