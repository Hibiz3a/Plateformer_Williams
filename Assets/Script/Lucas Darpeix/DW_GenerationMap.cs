using UnityEngine;

public class GenerationMap : MonoBehaviour
{
    [SerializeField] private int _seed;
    [SerializeField] private Transform _player;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _block;
    [SerializeField] private float _chanceSpawn;
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int y = (int)_player.position.y - 2; y > (int)_player.position.y - _height; y--)
        {
            for (int x = 0; x < _width; x++)
            {
                if (Mathf.PerlinNoise(x / 10f + _seed, y / 10f + _seed) >= _chanceSpawn)
                {
                    Instantiate(_block, new Vector3(x, y), Quaternion.identity, gameObject.transform);
                }
            }
        }
    }
}
