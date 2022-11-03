using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMotion : MonoBehaviour
{
    public float speed = 0.1f;
    public  Texture texture;
    Vector2 backgroundPosition;

    private MeshRenderer background;

    private void Start()
    {
        background = this.GetComponent<MeshRenderer>();
        //background.material.mainTexture  = texture;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        background.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
    }
}