using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int[] not_timer_level;
    [SerializeField] private AudioClip sfx_;
    [SerializeField] private AudioSource audioSource;


    public float timeRemaining = 85500; // 23:45
    public bool timerIsRunning = false;
    public int sceneToLoad = 0;

    private static Timer instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (canvas != null)
            {
                DontDestroyOnLoad(canvas.gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {

        CheckAndDestroyTimer();


        if (timerIsRunning)
        {
            if (timeRemaining < 24 * 60 * 60)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's up. Loading the designated scene.");
                timerIsRunning = false;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay % 3600) / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void WrongAnswer()
    {
        SFX_audio();
        timeRemaining += 60;
    }




    private void SFX_audio()
    {
        if (audioSource != null && sfx_ != null) { audioSource.PlayOneShot(sfx_); }
    }






    private void CheckAndDestroyTimer()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        foreach (int level in not_timer_level)
        {
            if (sceneIndex == level)
            {
                audioSource.Stop();
                Destroy(gameObject);
                return;
            }
        }
    }
}
