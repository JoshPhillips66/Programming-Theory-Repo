using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    private void Awake()
    {
        pointValue = 50;
        health = 6f;
        moveSpeed = 3f;
        damageCaused = 2.5f;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }


}
