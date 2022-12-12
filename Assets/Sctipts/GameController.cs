using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instanceGameController;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public Text timerUI;
    [SerializeField] private float secondsRemaining = 19;
    private string timeOutput;
    public int itemCount = 0;

    private void Awake()
    {
        if (instanceGameController == null)
        {
            instanceGameController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        UpdateCountdownTimer();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        itemCount = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Stage1");
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        Time.timeScale = 1;
        secondsRemaining = 19;
    }

    private void UpdateCountdownTimer()
    {
        timeOutput = string.Format("{0:00}:{1:00}", secondsRemaining, (secondsRemaining * 100.0f) % 100.0f);
        secondsRemaining -= Time.deltaTime;
        timerUI.text = timeOutput;

        if (secondsRemaining <= 0)
        {
            ShowGameOver();
        }
    }
}
