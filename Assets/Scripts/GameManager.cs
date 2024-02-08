using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public int maxTime;
    int timeRemaining;
    [SerializeField] TextMeshProUGUI scoreUI, timerUI, finalScoreUI;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject finishUI;
    private void Start()
    {
        GameEvents.CollectCoin.AddListener(AddScore);
        timeRemaining = maxTime;
        timerUI.text = timeRemaining.ToString();
        GameEvents.SpawnCoin.Invoke();
        scoreUI.text = $"Score: {score}";
        Invoke("CountDown", 1);
    }

    void AddScore(int value)
    {
        score += value;
        scoreUI.text = $"Score: {score}";
    }

    void CountDown() 
    {
        timeRemaining--;
        timerUI.text = timeRemaining.ToString();

        if(timeRemaining % 2 == 0)
        {
            GameEvents.SpawnCoin.Invoke();
        }

        if(timeRemaining > 0)
        {
            Invoke("CountDown", 1);
        }
        else
        {
            scoreUI.gameObject.SetActive(false);
            timerUI.gameObject.SetActive(false);
            playerController.enabled = false;
            finishUI.gameObject.SetActive(true);
            finalScoreUI.text = $"Final Score: {score}";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
