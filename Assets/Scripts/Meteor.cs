using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed = 1;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void Update()
    {
        if (transform.position.x < -12) {
             Destroy(gameObject);
        }
        transform.position += Vector3.left * Time.deltaTime * speed;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 10));
    }

    void OnCollisionEnter2D(Collision2D other) {
    }
}
