using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DeathCam : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private GameManager gameManager;
    private int deathPriority = 50;
    // Start is called before the first frame update
    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        gameManager = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameManager.gameOver)
        {
            virtualCamera.Priority = deathPriority;
            Debug.Log("The DEATH camera should be active");
        }

    }
}
