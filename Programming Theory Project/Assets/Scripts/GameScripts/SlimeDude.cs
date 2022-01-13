using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDude : FastEnemy
{
    AudioSource audioSource;
    public AudioClip slimeDudeClip;
    float lastPlay;



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
        audioSource = GetComponent<AudioSource>();

        lastPlay = Time.time;
        
    }

    public override void PlaySounds()
    {
        if (!isDead && !playerController.IsDead()  && Time.time - lastPlay > 1.1f)
        {
           audioSource.Play();
            lastPlay = Time.time;
        }
    }

}
