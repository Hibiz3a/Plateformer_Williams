using UnityEngine;

public class SD_BoxBehaviour : MonoBehaviour
{
    [SerializeField] private float TimeLimit;
    private SD_movement Player;

    public void Init(SD_movement _player)
    {
        Player = _player;
    }

    private void Update()
    {
        TimeLimit -= Time.deltaTime;
        if (TimeLimit <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
