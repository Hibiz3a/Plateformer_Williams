using UnityEngine;

public class SC_DoorTeleport : MonoBehaviour
{
    [SerializeField] private GameObject fakeDoor;
    [SerializeField] private GameObject realDoor;
    [SerializeField] private Animator animationSmooth;
    [SerializeField] private string animName;

    private void Start()
    {
        fakeDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationSmooth.Play(animName);
        }
    }
}
