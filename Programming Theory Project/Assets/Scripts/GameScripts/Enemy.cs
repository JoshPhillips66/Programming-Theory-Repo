using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float health { get; set; } = 5f;
    protected float moveSpeed { get; set; } = 5f;
    protected float damageCaused { get; set; } = 1f;
    protected int pointValue { get; set; } = 10;

    public float knockbackForce = 8f;
    public float rotationSpeed = 80f;
    public GameManager gameManager;
    protected GameObject player;
    protected Rigidbody enemyRb;
    protected PlayerController playerController;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!gameManager.gameOver)
        {
            Move();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GotHit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DoDamage();
        }
    }
    protected void Move()
    {
        //Get direction toward the player
        Vector3 lookAt = player.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
        //rotate in move direction
        transform.LookAt(lookAt);
        Vector3 moveDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).normalized;
        //move toward the player
        transform.position += ( moveDirection * moveSpeed * Time.deltaTime);
    }

    public void GotHit()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 hitDirection = new Vector3(playerPos.x - transform.position.x, 0, playerPos.z - transform.position.z).normalized;
        hitDirection *= -1;
        hitDirection.y = .2f;
        //knockback
        enemyRb.AddForce(hitDirection * knockbackForce, ForceMode.Impulse);

        health -= 1;
        if (health <= 0)
        {
            ScorePoints(pointValue);
            Destroy(gameObject);
            
        }
    }

    protected void DoDamage()
    {
        //Do damage to the player
        playerController.TakeHit(damageCaused, transform.position);
    }

    public virtual void ScorePoints(int points)
    {
        gameManager.AddScore(points);
    }
}
