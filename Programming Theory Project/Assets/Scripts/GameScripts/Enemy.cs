using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float health { get; set; } = 5f;
    protected float moveSpeed { get; set; } = 5f;
    protected float damageCaused { get; set; } = 1f;

    public float knockbackForce = 8f;
    public float rotationSpeed = 80f;

    protected GameObject player;
    protected Rigidbody enemyRb;
    protected PlayerController playerController;



    private void Awake()
    {

        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        Move();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            Destroy(other.gameObject);
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

    protected void GotHit()
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
            Destroy(gameObject);
        }
    }

    protected void DoDamage()
    {
        //Do damage to the player
        playerController.TakeHit(damageCaused, transform.position);
    }
}
