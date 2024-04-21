using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public Animator GameOverAnimator;

    private void Awake()
    {
        MakeInstance();
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverAnimator.Play("FadeIn");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameOverAnimator.Play("FadeOut");
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
