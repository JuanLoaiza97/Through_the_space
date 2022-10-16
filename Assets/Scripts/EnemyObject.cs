using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public Sprite[] sprites;
    public float speed;
    public float damage;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void Update()
    {
        Move(speed);
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void Move(float speed)
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 10));
    }
}
