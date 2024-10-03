using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MG_End : MonoBehaviour
{
    private float InitPos;
    private float MoveSpeed = 1.5f;
    [SerializeField] public GameObject EndPrefab;
    [SerializeField] public MG_Player PlayerSC;
    public bool PlayerIsOnEndPlatform = false;
    private void Start()
    {
        InitPos = EndPrefab.transform.position.y;
    }
    private void Update()
    {
        if(PlayerIsOnEndPlatform)
        {
            Debug.Log("salput");
            EndPrefab.transform.position = Vector3.MoveTowards(EndPrefab.transform.position, new Vector3(0, InitPos--, 0), MoveSpeed * Time.deltaTime);
        }
        if(EndPrefab.transform.position.y <= 94.0f)
        {
            PlayerIsOnEndPlatform = false;
            Debug.Log("fdp");
        }
    }
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.collider.name == "Obstacle")
        {
            PlayerSC.IsOnFirstPlatform = false;
            PlayerIsOnEndPlatform = true;
        }
    }
}
