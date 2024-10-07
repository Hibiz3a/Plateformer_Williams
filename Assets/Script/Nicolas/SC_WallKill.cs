using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_WallKill : MonoBehaviour
{
    [SerializeField] private GameObject wallTrap;
    [SerializeField] private Transform respawnPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           collision.transform.position = respawnPlayer.position;
        }
    }
}
