using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{


    private void Awake()
    {
        knockbackForce = 7f;
        pointValue = 25;
        health = 3f;
        moveSpeed = 8f;
        damageCaused = 1f;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    
}
