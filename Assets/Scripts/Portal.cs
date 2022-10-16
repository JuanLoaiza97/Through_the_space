using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float speed = 3;
    private void Update()
    {
         transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 10));
        if (transform.position.x > 0)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
    }
}
