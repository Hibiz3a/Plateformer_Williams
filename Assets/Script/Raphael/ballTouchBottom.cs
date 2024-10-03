using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballTouchBottom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            string CurrentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(CurrentSceneName);
        }
    }
}
