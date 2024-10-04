using UnityEngine;

public class GenerationMap : MonoBehaviour
{
    [SerializeField] private int _seed;
    [SerializeField] private Transform _player;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _spike;
    [SerializeField] private float _chanceSpawn;
    [SerializeField] private int _chanceSpawnSpike;
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
                else if (Mathf.PerlinNoise(x / 10f + _seed, (y - 1) / 10f + _seed) >= _chanceSpawn)
                {
                    _chanceSpawnSpike++;
                    if (_chanceSpawnSpike > 10)
                    {
                        _chanceSpawnSpike = 0;
                        Instantiate(_spike, new Vector3(x, y - 0.211f), Quaternion.identity, gameObject.transform);
                    }
                }
            }
        }
    }
}
