using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    AudioSource audioSource;
    public AudioClip[] monsterSounds;
    private float lastTime;

    private void Awake()
    {
        knockbackForce = 1f;
        pointValue = 50;
        health = 6f;
        moveSpeed = 4.5f;
        damageCaused = 3f;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();

        lastTime = 0f;
    }

    public override void GotHit()
    {
        base.GotHit();
        
        if (isDead == false && Time.time - lastTime > .28f)
        {
            audioSource.PlayOneShot(monsterSounds[0]);
        }
        lastTime = Time.time;
    }
}
