using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickList : MonoBehaviour
{
    public List<GameObject> AllBricks = new List<GameObject>();
    public GameObject End;
    protected virtual void Start()
    {
        for(int i=0; i < transform.childCount; i++)
        {
            var BrickTransform=transform.GetChild(i);
            AllBricks.Add(BrickTransform.gameObject);
        }
    }
    protected virtual void VerifyBrickActive()
    {

    }
}
