using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusPool : MonoBehaviour
{
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            growRaq();
            Destroy(gameObject);
            
        }
    }
    private void growRaq()
    {
        RaquetteMovement raq = Object.FindObjectOfType<RaquetteMovement>();
        raq.transform.localScale= new Vector3(6, raq.transform.localScale.y, raq.transform.localScale.z);
        raq.growned = true;
    }

}
