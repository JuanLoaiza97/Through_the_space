using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public float speed;
    public float healing;
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
