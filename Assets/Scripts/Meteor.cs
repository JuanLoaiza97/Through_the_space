using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {
        speed = Random.Range(2, 6);
       
    }

    void Update()
    {
        if (transform.position.x < -12) {
             Destroy(gameObject);
        }
        transform.position += Vector3.left * Time.deltaTime * speed;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 10));
        //transform.RotateAround(transform.position, Vector3.back, Time.deltaTime * speed * 10);
    }
}
