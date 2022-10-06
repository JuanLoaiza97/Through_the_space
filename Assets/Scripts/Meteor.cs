using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {
        Destroy(gameObject, 20);
    }

    void Update()
    {
        speed = Random.Range(1, 7);
        transform.position += -transform.right * Time.deltaTime * speed;
    }
}
