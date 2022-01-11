using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManger : MonoBehaviour
{
    public TMP_InputField nameField;

    public GameObject highScorePopup;
    public TextMeshProUGUI highScoreNames;
    public TextMeshProUGUI highScores;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        nameField.text = DataManager.Instance.GetPlayerName();
    }

    public void DisplayHighScores()
    {
        int[] playerScores = DataManager.Instance.GetHighScoreArray();
        string[] playerNames = DataManager.Instance.GetHighPlayerArray();
        string tempString = string.Empty;
        for (int i = 0; i < playerScores.Length; i++)
        {
            if (playerScores[i] != 0)
            {
                tempString += playerScores[i] + "\n";
            }
        }
        highScores.text = tempString;
        tempString = string.Empty;
        for (int i = 0; i < playerNames.Length; i++)
        {
            tempString += playerNames[i] + "\n";
        }
        highScoreNames.text = tempString;

        highScorePopup.SetActive(true);
    }

    public void NameEntered()
    {
        //TODO
        DataManager.Instance.SetPlayerName(nameField.text);
    }

    public void StartGame()
    {
        DataManager.Instance.SaveAll();
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        //TODO
        DataManager.Instance.SaveAll();
    }

    public void BackButton()
    {
        highScorePopup.SetActive(false);
    }
}
