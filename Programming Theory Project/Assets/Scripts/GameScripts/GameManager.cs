using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void QuitGame()
    {
        //Send game to Menu scene 0 is the Menu
        DataManager.Instance.SaveAll();
        SceneManager.LoadScene(0);
    }
}
