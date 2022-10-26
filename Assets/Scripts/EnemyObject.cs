using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : ProjectileMotion
{
    public Sprite[] sprites;
    public float damage;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void Update()
    {
        Move();
        Rotation();
        ValidateDestroy();
    }
}
