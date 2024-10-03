using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float Score = 0f;
    private float Timer = 0f;
    private float CurrentTimer = 0f;

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

        CurrentTimer = Timer;

        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        CurrentTimer--;
        TimerToZero();
    }

    private void TimerToZero()
    {
        if (Timer <= 0f)
        {
            Debug.Log("Your Dead....");
        }
    }

    public void NextLevel(float _levelTime)
    {
        NormalizeScore(1, _levelTime);
        CurrentScene++;
        CurrentTimer = Timer;
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

    private void NormalizeScore(int multiplicateur, float _levelTime)
    {
        float _normalizedTimer = CurrentTimer / _levelTime;

        Score = Score + _normalizedTimer * multiplicateur;
    }
}