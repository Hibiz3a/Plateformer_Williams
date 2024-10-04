using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvementz : MonoBehaviour
{
    public float moveSpeed = 2;
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, -10);
    }
}
