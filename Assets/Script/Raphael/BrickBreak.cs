using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BrickBreak : BrickList
{
    
    protected override void Start()
    {
        End = null;
    }
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("Player"))
        {

            BrickList Parent = transform.parent.gameObject.GetComponent<BrickList>();
            gameObject.SetActive(false);
            VerifyBrickActive();
            int chance = Random.Range(0, 100);
            if (chance > 45)
            {
                Instantiate(Parent.boostPrefab, transform.position,Parent.boostPrefab.transform.rotation);
            }

        }
    }
    protected override void VerifyBrickActive()
    {
        List<GameObject> BricksActive=new List<GameObject>();
        BrickList Parent = transform.parent.gameObject.GetComponent<BrickList>();
        foreach(GameObject bricks in Parent.AllBricks.Where(x => x.activeSelf == true))
        {
           BricksActive.Add(bricks); 
        }

        
        if (!BricksActive.Any())
        {
            Parent.End.SetActive(true);
        }
    }
}
