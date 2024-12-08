using System.Collections;
using UnityEngine;

public class SC_TrapKiller : MonoBehaviour
{
    [SerializeField] private Animator killTrapAnim;
    [SerializeField] private string nameAnimTrap;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            killTrapAnim.Play(nameAnimTrap);
        }
    }
}
