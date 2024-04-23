using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public GameObject gameOverPanel;
    public int score;

    private Animator gameOverAnimator;
    private Text scoreText;
    private Text highScore;

    private void Awake()
    {
        MakeInstance();
        gameOverAnimator = gameOverPanel.GetComponent<Animator>();
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        highScore = GameObject.Find("HighScore Text").GetComponent<Text>();
    }

    public void GameOver()
    {
        // if the playerpref contains a score, check if the current score is greater than the stored score
        if (PlayerPrefs.HasKey("Score"))
        {
            if (score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Score", score);
        }

        scoreText.text = "Score: " + score.ToString();
        highScore.text = "High Score: " + PlayerPrefs.GetInt("Score").ToString();
        Time.timeScale = 0f;
        gameOverAnimator.Play("FadeIn");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverAnimator.Play("FadeOut");
        SceneManager.LoadScene("New");
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
