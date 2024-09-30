using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float Score = 0f;
    private float Timer = 0f;

    public float _score
    {
        get { return Score; }
    }

    public float _timer
    {
        get { return Timer; }
    }

    public static GameManager Instance;

    private int CurrentScene;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        Timer -= 1;
    }

    private void TimerToZero()
    {
        if (Timer <= 0f)
        {
            Debug.Log("Your Dead...");
        }
    }

    public void IncreaseScore(float _score)
    {
        Score += _score;
    }

    public void DecreaseScore(float _score)
    {
        Score -= _score;
    }

    public void NextLevel()
    {
        CurrentScene++;
        SceneManager.LoadScene(CurrentScene);
        End();
    }

    private void End()
    {
        if (CurrentScene == 15)
        {
            Application.Quit();
        }
    }
}