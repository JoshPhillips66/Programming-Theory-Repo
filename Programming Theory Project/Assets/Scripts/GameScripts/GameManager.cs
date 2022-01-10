using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPositions;
    public GameObject[] enemies;
    private float spawnRate = 5f;

    private float lastSpawnTime = 0f;
    private int numSpawnPositions;
    private int numEnemies;

    void Start()
    {
        numSpawnPositions = spawnPositions.Length;
        numEnemies = enemies.Length;
    }


    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (Time.time > lastSpawnTime + spawnRate)
        {
            int spawnPos = Random.Range(0, numSpawnPositions);
            int enemyToSpawn = Random.Range(0, numEnemies);
            Instantiate(enemies[enemyToSpawn], spawnPositions[spawnPos].transform.position, Quaternion.identity);
            Debug.Log("Spawn an enemy");
            lastSpawnTime = Time.time;
        }
    }

    public void QuitGame()
    {
        //Send game to Menu scene 0 is the Menu
        DataManager.Instance.SaveAll();
        SceneManager.LoadScene(0);
    }
}
