using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject bombPrefab;

    private float minX = -2.5f;
    private float maxX = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        Instantiate (bombPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y), Quaternion.identity);
        StartCoroutine(SpawnBomb());
    }

}
