using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Enemy enemyHit;
    private float bulletSpeed = 50f;
    //private float timeToDestroy = 3f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }


    private void OnEnable()
    {


    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed * Time.deltaTime);
      if (Vector3.Distance(transform.position, target) < .01f)
      {
        Destroy(gameObject);
       }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
