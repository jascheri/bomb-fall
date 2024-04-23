using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public GameObject scoreText;

    private void addScore()
    {
        GameplayController.instance.score++;
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + GameplayController.instance.score;
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
