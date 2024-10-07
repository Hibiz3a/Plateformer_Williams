using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeInFadeOutCanvasGroup;
    [SerializeField] private CanvasGroup ScoreAndTime;

    [SerializeField] private TextMeshProUGUI ScoreGUI;
    [SerializeField] private TextMeshProUGUI TimeGUI;
    [SerializeField] private TextMeshProUGUI LevelGUI;
    [SerializeField] private TextMeshProUGUI ScoreGainGUI;
    [SerializeField] private GameObject EndLevel;

    [SerializeField] private GameObject SkipLevelGO;
    
    private float Score = 0f;
    private float Timer = 0f;
    private float CurrentTimer = 0f;
    private int CurrentScene = 0;
    private bool NewLevel = false;
    public static GameManager Instance;

    public float _score
    {
        get { return Score; }
    }

    public float _timer
    {
        get { return Timer; }
    }



    void Start()
    {
        EndLevel.SetActive(false);
        ScoreGUI.text = "Score : " + Mathf.RoundToInt(Score);
        TimeGUI.text = "Time : " + CurrentTimer;
        LevelGUI.text = "Niveau : " + 1;

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
        if (NewLevel || CurrentScene == 0)
        {
            CurrentTimer += Time.deltaTime;
            TimeGUI.text = "Time : " + Mathf.RoundToInt(CurrentTimer);
        }
        //TimerToZero();
    }

    /*private void TimerToZero()
    {
        if (Timer <= 0f)
        {
            Debug.Log("Your Dead....");
        }
    }*/

    public void NextLevel(float _levelTime, int _level, int _levelscore = 100)
    {
        if (CurrentScene <= 14)
        {
            NormalizeScore(_levelscore, _levelTime);
            ScoreGUI.text = "Score : " + Mathf.RoundToInt(Score);
            CurrentTimer = Timer;
            CurrentScene++;
            StartCoroutine(FadeInFadeOut(_level));
            if(CurrentScene == 15)
            {
                SkipLevelGO.SetActive(false);
            }
        }
        else
        {
            EndLevel.SetActive(true);
            ScoreGainGUI.text = " " + Score;
        }
        
    }

    public void SkipLevel()
    {
        if (CurrentScene <= 14)
        {
            CurrentTimer = Timer;
            CurrentScene++;
            StartCoroutine(FadeInFadeOut(CurrentScene + 1));
        }
    }

    private IEnumerator FadeInFadeOut(int _level)
    {
        float alpha = 0;
        float beta = 1;
        for (int i = 0; i < 10; i++)
        {
            alpha += 0.10f;
            beta -= 0.10f;
            fadeInFadeOutCanvasGroup.alpha = alpha;
            ScoreAndTime.alpha = beta;
            yield return new WaitForSeconds(0.05f);
        }

        LevelGUI.text = "Niveau : " + _level;
        yield return new WaitForSeconds(2f);
        //CurrentScene++;
        SceneManager.LoadScene(CurrentScene);
        for (int i = 0; i < 10; i++)
        {
            alpha -= 0.10f;
            beta += 0.10f;
            fadeInFadeOutCanvasGroup.alpha = alpha;
            ScoreAndTime.alpha = beta;
            yield return new WaitForSeconds(0.05f);
        }
        NewLevel = true;
    }


    public void End()
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