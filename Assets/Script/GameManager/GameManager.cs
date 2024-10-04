using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeInFadeOutCanvasGroup;

    [SerializeField] private TextMeshProUGUI ScoreGUI;
    [SerializeField] private TextMeshProUGUI TimeGUI;

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

    private int CurrentScene = 0;

    void Start()
    {
        ScoreGUI.text = "Score : " + Mathf.RoundToInt(Score);
        TimeGUI.text = "Time : " + CurrentTimer;

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

    private void Update()
    {
        CurrentTimer += Time.deltaTime;
        TimeGUI.text = "Time : " + Mathf.RoundToInt(CurrentTimer);
        //TimerToZero();
    }

    /*private void TimerToZero()
    {
        if (Timer <= 0f)
        {
            Debug.Log("Your Dead....");
        }
    }*/

    public void NextLevel(float _levelTime, int _levelscore = 100)
    {
        StartCoroutine(FadeInFadeOut());
        NormalizeScore(_levelscore, _levelTime);
        CurrentTimer = Timer;
        ScoreGUI.text = "Score : " + Mathf.RoundToInt(Score);
    }

    private IEnumerator FadeInFadeOut()
    {
        float alpha = 0;
        for (int i = 0; i < 10; i++)
        {
            alpha += 0.10f;
            fadeInFadeOutCanvasGroup.alpha = alpha;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);
        CurrentScene++;
        End();
        SceneManager.LoadScene(CurrentScene);
        for (int i = 0; i < 10; i++)
        {
            alpha -= 0.10f;
            fadeInFadeOutCanvasGroup.alpha = alpha;
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void End()
    {
        if (CurrentScene >= 15)
        {
            Application.Quit();
        }
    }

    private void NormalizeScore(int _levelScore, float _levelTime)
    {
        float _normalizedTimer = (_levelTime / CurrentTimer) + 1;

        Score = Score + (_levelScore * _normalizedTimer);
    }
}