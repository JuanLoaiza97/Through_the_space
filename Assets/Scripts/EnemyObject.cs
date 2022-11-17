using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : ProjectileMotion
{
    public Sprite[] sprites;
    public GameObject explosionEffect;
    public float damage;
    public bool rotation;
    private void Start()
    {
        if (sprites != null && sprites.Length > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }

    private void Update()
    {
        Move();
        ValidateDestroy();
        if (rotation)
        {
            Rotation();
        }
    }

    public void Destroy()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
