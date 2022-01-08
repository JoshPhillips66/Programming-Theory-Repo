using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private string playerName;

    private string highScoreName;
    private int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadAll();
    }



    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScoreName;
        public int highScore;
    }

    public void UpdateHighScore(string playerName, int score)
    {
        if (score > highScore)
        {
            highScoreName = playerName;
            highScore = score;
            SaveHighScore();
        }
    }

    public void SetPlayerName(string currentPlayer)
    {
        playerName = currentPlayer;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public string GetHighScoreName()
    {
        return highScoreName;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.jason";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScoreName = data.highScoreName;
            highScore = data.highScore;

        }
    }

}
