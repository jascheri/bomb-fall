using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public GameObject scoreText;
    private int score;

    private void addScore()
    {
        score++;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Bomb")
        {
            addScore();
            collision.gameObject.SetActive(false);
        }
    }
}
