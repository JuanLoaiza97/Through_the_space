using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speedMove = 0;
    public float speedHorizontal = 3;
    public float speedVertical = 3;
    public Joystick joystick;

    public Vector2 limitSup = Vector2.zero;
    public Vector2 limitSub = Vector2.zero;

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
        /* if (limitSup.y >= transform.position.y && transform.position.y >= limitSub.y)
        {
            Debug.Log("Y: "+ limitSup.y+ " > " + transform.position.y + " > " + limitSub.y);
            
        }
        else
        {
            Debug.Log(" Y fuera de rango " + limitSup.y+ " > " + transform.position.y + " > " + limitSub.x);
        } */

       /*  if (limitSup.x >= transform.position.x && transform.position.x >= limitSub.x)
         //{
/*             Debug.Log("X: "+limitSup.x+ " > " + transform.position.x + " > " + limitSub.x); */
            horizontalMove = joystick.Horizontal * speedHorizontal;
        //}
/*         else
        {
            Debug.Log("X fuera de rango "+limitSup.x+ " > " + transform.position.x + " > " + limitSub.x);
        } */
        
        transform.position += new Vector3(horizontalMove, verticalMove).normalized * Time.deltaTime * speedMove;
    }
}
