using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("Thomas_Plateformer");
            CanMoove = true;
        }
    }

    public void StopLevel()
    {
        CanMoove = false;
    }
}
