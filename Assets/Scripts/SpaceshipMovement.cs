using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{

    [Header("Move")]
    public float speedMove;
    public Joystick joystick;

    [Header("Rage move")]
    public float maximoY;
    public float minimoY;
    public float maximoX;
    public float minimoX;

    void Update()
    {
        float verticalMove = joystick.Vertical;
        float horizontalMove = joystick.Horizontal;

        transform.position += new Vector3(horizontalMove, verticalMove).normalized * Time.deltaTime * speedMove;

        //Limita el rango de movimiento
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY));
    }
}
