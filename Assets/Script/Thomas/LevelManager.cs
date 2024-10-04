using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float InitialLevelXPosition;
    public GameObject Player;
    public int LevelMovementSpeed;

    private bool CanMoove = true;

    private void Start()
    {
        InitialLevelXPosition =  transform.position.x;
    }

    void Update()
    {
        TranslateLevel();
    }


    public void TranslateLevel()
    {
        if (CanMoove)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(InitialLevelXPosition--, 0, 0), LevelMovementSpeed * Time.deltaTime);
        }
        if (!CanMoove)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.transform.position = new Vector3(0, 0, 0);
            Player.transform.position = new Vector3(-7, -3.5f, 0);
            Player.GetComponent<Rigidbody2D>().gravityScale = 3;
            CanMoove = true;
        }
    }

    public void StopLevel()
    {
        CanMoove = false;
    }
}
