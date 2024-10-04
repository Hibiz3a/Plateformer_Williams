using UnityEngine;

public class DW_Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<DW_FollowCamera>().ResetPlayer();
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
