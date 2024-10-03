using UnityEngine;

public class SC_DisableAndEnableWall : MonoBehaviour
{
    [SerializeField] private GameObject disableWall;
    [SerializeField] private GameObject enableWall;
    [SerializeField] private Animator animationSmooth;
    [SerializeField] private string animName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationSmooth.Play(animName);
        }
    }

}
