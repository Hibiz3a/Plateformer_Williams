using UnityEngine;

public class BD_FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;

    void Update()
    {
        transform.position = new Vector3(m_Player.transform.position.x, transform.position.y, transform.position.z);
    }
}
