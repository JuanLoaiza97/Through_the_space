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
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
