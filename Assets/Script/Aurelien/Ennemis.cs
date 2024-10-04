using System.Collections;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    [SerializeField] private Transform dest1;
    [SerializeField] private Transform dest2;
    [SerializeField] private float speed;
    [SerializeField] private bool goingRight = false;
    private Transform _transform;

    void Start()
    {
        _transform = transform;

        StartCoroutine(DeplacementsX());
    }

    private IEnumerator DeplacementsX()
    {
        while (goingRight)
        {
            _transform.position = new Vector2(_transform.position.x + speed, _transform.position.y);
            yield return new WaitForSeconds(0.01f);
            if (_transform.position.x >= dest2.position.x)
            {
                goingRight = false;
            }
        }
        yield return new WaitForSeconds(0.5f);
        while (!goingRight)
        {
            _transform.position = new Vector2(_transform.position.x - speed, _transform.position.y);
            yield return new WaitForSeconds(0.01f);
            if (_transform.position.x <= dest1.position.x)
            {
                goingRight = true;
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(DeplacementsX());
    }
}
