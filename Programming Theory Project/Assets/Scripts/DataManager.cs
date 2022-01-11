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

    public HighScoreEntry[] topTenScores;


    private void Awake()
    {
        topTenScores = new HighScoreEntry[10];
        for (int i = 0; i < topTenScores.Length; i++)
        {
            topTenScores[i] = new HighScoreEntry();
        }

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadAll();



    }

    public class HighScoreEntry
    {
        public int myScore = 0;
        public string myName = "";

    }


    [System.Serializable]
    class SaveData
    {
        public HighScoreEntry[] highScoreArray;
        public string playerName;
        public string highScoreName;
        public int highScore;
        public int highScore1;
        public int highScore2;
        public int highScore3;
        public int highScore4;
        public int highScore5;
        public int highScore6;
        public int highScore7;
        public int highScore8;
        public int highScore9;
        public int highScore10;
        public string highPlayer1;
        public string highPlayer2;
        public string highPlayer3;
        public string highPlayer4;
        public string highPlayer5;
        public string highPlayer6;
        public string highPlayer7;
        public string highPlayer8;
        public string highPlayer9;
        public string highPlayer10;

    }

    public void UpdateHighScore(string playerName, int score)
    {
        if (score > highScore)
        {
            highScoreName = playerName;
            highScore = score;

        }
        //replaces last score on list with the new entry
        if (score > topTenScores[topTenScores.Length - 1].myScore)
        {
            topTenScores[topTenScores.Length -1].myScore = score;
            topTenScores[topTenScores.Length - 1].myName = playerName;
        }
        //Sort High Scores
        HighScoreEntry temp = new HighScoreEntry();
        for (int i = topTenScores.Length - 1; i >0; --i)
        {
            if (topTenScores[i].myScore > topTenScores[i-1].myScore)
            {
                temp = topTenScores[i];
                topTenScores[i] = topTenScores[i-1];
                topTenScores[i-1] = temp;

            } else
            {
                break;
            }
        }
        SaveAll();
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

    public int[] GetHighScoreArray()
    {
        int[] temp = new int[10];
        for (int i = 0; i < 10; i++)
        {
            temp[i] = topTenScores[i].myScore;
        }

        return temp;
    }

    public string[] GetHighPlayerArray()
    {
        string[] temp = new string[10];
        for (int i = 0; i < 10; i++)
        {
            temp[i] = topTenScores[i].myName;
        }

        return temp;
    }

/*    private void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        data.highScoreArray = topTenScores;

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
            topTenScores = data.highScoreArray;
        }
    }*/

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        data.highScore1 = topTenScores[0].myScore;
        data.highScore2 = topTenScores[1].myScore;
        data.highScore3 = topTenScores[2].myScore;
        data.highScore4 = topTenScores[3].myScore;
        data.highScore5 = topTenScores[4].myScore; 
        data.highScore6 = topTenScores[5].myScore;
        data.highScore7 = topTenScores[6].myScore;
        data.highScore8 = topTenScores[7].myScore;
        data.highScore9 = topTenScores[8].myScore;
        data.highScore10 = topTenScores[9].myScore;
        data.highPlayer1 = topTenScores[0].myName;
        data.highPlayer2 = topTenScores[1].myName;
        data.highPlayer3 = topTenScores[2].myName;
        data.highPlayer4 = topTenScores[3].myName;
        data.highPlayer5 = topTenScores[4].myName;
        data.highPlayer6 = topTenScores[5].myName;
        data.highPlayer7 = topTenScores[6].myName;
        data.highPlayer8 = topTenScores[7].myName;
        data.highPlayer9 = topTenScores[8].myName;
        data.highPlayer10 = topTenScores[9].myName;
        


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
            topTenScores[0].myScore = data.highScore1;
            topTenScores[1].myScore = data.highScore2;
            topTenScores[2].myScore = data.highScore3;
            topTenScores[3].myScore = data.highScore4;
            topTenScores[4].myScore = data.highScore5;
            topTenScores[5].myScore = data.highScore6;
            topTenScores[6].myScore = data.highScore7;
            topTenScores[7].myScore = data.highScore8;
            topTenScores[8].myScore = data.highScore9;
            topTenScores[9].myScore = data.highScore10;
            topTenScores[0].myName = data.highPlayer1;
            topTenScores[1].myName = data.highPlayer2;
            topTenScores[2].myName = data.highPlayer3;
            topTenScores[3].myName = data.highPlayer4;
            topTenScores[4].myName = data.highPlayer5;
            topTenScores[5].myName = data.highPlayer6;
            topTenScores[6].myName = data.highPlayer7;
            topTenScores[7].myName = data.highPlayer8;
            topTenScores[8].myName = data.highPlayer9;
            topTenScores[9].myName = data.highPlayer10;

        }
    }


}
