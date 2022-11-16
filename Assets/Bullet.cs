using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProjectileMotion
{
    public GameObject explosionEffect;
    void Start()
    {
        
    }

 
    void Update()
    {
        Move();
        if (transform.position.x > destroyLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Boss"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
