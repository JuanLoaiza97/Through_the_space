using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speedMove = 0;
    public float speedHorizontal = 3;
    public float speedVertical = 3;
    public Joystick joystick;

    private float horizontalMove = 0;
    private float verticalMove = 0;
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalMove = joystick.Vertical * speedVertical;
        horizontalMove = joystick.Horizontal * speedHorizontal;
        transform.position += new Vector3(horizontalMove, verticalMove, 0) * Time.deltaTime * speedMove;
    }
}
