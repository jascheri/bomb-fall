using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10f;
    private float minX = -2.5f;
    private float maxX = 2.5f;
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 playerPosition = transform.position;
        // Move player right
        if(h>0)
        {
            playerPosition.x += speed * Time.deltaTime;
        }
        // Move player left
        else if (h<0)
        {
            playerPosition.x -= speed * Time.deltaTime;
        }
        // Restrict player to the game area
        playerPosition.x = Mathf.Clamp(playerPosition.x, minX, maxX);
        transform.position = playerPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb")
        {
            Time.timeScale = 0;
        }
    }
} // class end
