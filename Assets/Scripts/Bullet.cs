using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProjectileMotion
{
    public GameObject explosionEffect;

    public float damage;
 
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
            other.gameObject.GetComponent<Gabrielon>().TakeDamage(damage);
            Instantiate(explosionEffect, transform.position + new Vector3(0 , 0 , -5), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
