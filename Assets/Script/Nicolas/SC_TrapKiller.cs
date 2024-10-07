using System.Collections;
using UnityEngine;

public class SC_TrapKiller : MonoBehaviour
{
    [SerializeField] private GameObject Trap;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Trap.SetActive(true);
            StartCoroutine(chronoTrap());
        }
    }

    private IEnumerator chronoTrap()
    {
        yield return new WaitForSeconds(1.5f);
        Trap.SetActive(false);
    }
}
