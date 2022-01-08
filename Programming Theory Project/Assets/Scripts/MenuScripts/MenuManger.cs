using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManger : MonoBehaviour
{
    public TMP_InputField nameField;

    private void Awake()
    {
        nameField.text = DataManager.Instance.GetPlayerName();
    }

    public void DisplayHighScores()
    {
        //TODO
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
    }
}
