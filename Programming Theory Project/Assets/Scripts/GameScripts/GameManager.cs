using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject gameOverUI;

    public PlayerController playerController;

    public GameObject[] spawnPositions;
    public GameObject[] enemies;
    private float spawnRate = 5f;

    private float lastSpawnTime = 0f;
    private int numSpawnPositions;
    private int numEnemies;
    private int enemyWaveSize = 6;
    private int enemiesSpawnedinWave = 0;
    private float minSpawnRate = .5f;
    private float spawnRateIncrement = .5f;

    private int score;
    private float playerHealth;

    public bool gameOver;

    void Start()
    {
        scoreText.text = "Score: 0";
        healthText.text = "Health: 5";
        numSpawnPositions = spawnPositions.Length;
        numEnemies = enemies.Length;
    }

    void Update()
    {
        if (!gameOver)
        {
            SpawnEnemies();
        }
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
            enemiesSpawnedinWave++;
            if (spawnRate >= minSpawnRate && enemiesSpawnedinWave >= enemyWaveSize)
            {
                spawnRate -= spawnRateIncrement;
                enemiesSpawnedinWave = 0;
            }
        }
    }

    public void QuitGame()
    {
        
        //Send game to Menu scene 0 is the Menu
        DataManager.Instance.SaveAll();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOver = true;
        playerController.inputActions.Default.Disable();
        Cursor.lockState = CursorLockMode.None;
        gameOverScoreText.text = "Score: " + score;
        gameOverUI.SetActive(true);
        DataManager.Instance.UpdateHighScore(DataManager.Instance.GetPlayerName(), score);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = ("Score: " + score);
    }

    public void UpdateHealth(float health)
    {
        playerHealth = health;
        healthText.text = ("Health: " + playerHealth);
    }
}
