using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float speed;
    public float destroyLimit;
    protected void Move()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    protected void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed * 10));
    }

    protected void ValidateDestroy()
    {
        if (transform.position.x < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
}
