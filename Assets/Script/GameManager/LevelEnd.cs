using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private float LevelTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.NextLevel(LevelTime);
        }
    }
}
