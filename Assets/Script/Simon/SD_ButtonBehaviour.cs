using UnityEngine;

public class SD_ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ButtonColor;
    [SerializeField] private SD_DoorBehaviour ConnectedDoor;
    private Color BaseColor;
    private Color PressedColor = new Color(0.5f, 0.5f, 0.5f, 1);
    private int PresserCount = 0;

    private void Start()
    {
        BaseColor = ButtonColor.color;
    }
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        PresserCount++;
        ButtonColor.color = PressedColor;
        if (PresserCount == 1)
        {
            ConnectedDoor.OpenDoor();
        }
    }
    private void OnCollisionExit2D(Collision2D _collision)
    {
        PresserCount--;
        if (PresserCount == 0)
        {
            ButtonColor.color = BaseColor;
            ConnectedDoor.CloseDoor();
        }
    }
}
