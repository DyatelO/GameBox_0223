using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float spawnTimer;
    [SerializeField] private GameObject player;

    private float timer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = GanerateRandomPosition();

        spawnPosition += new Vector2(player.transform.position.x, player.transform.position.y);

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = spawnPosition;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
        //newEnemy.GetComponent<Enemy>().Target = player.transform;

    }

    private Vector2 GanerateRandomPosition()
    {
        Vector2 position = new Vector2();

        float randomValue = Random.value > 0.5f ? - 1f : 1f;
        if(Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * randomValue;
        }
        else
        {
            position.x = spawnArea.x * randomValue;
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
        }



        return position;
    }
}
