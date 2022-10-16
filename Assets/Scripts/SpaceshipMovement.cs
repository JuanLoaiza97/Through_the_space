using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public GameOverPanel GameOverPanel;

    [Header("Life")]
    public BarLife barLife;
    public float life;
    public float currentLife;
    public int points;

    [Header("Move")]
    public float speedMove;
    public Joystick joystick;

    [Header("Rage move")]
    public float maximoY;
    public float minimoY;
    public float maximoX;
    public float minimoX;

    private void Start()
    {
        currentLife = life;
    }

    private void Update()
    {
        float verticalMove = joystick.Vertical;
        float horizontalMove = joystick.Horizontal;

        transform.position += new Vector3(horizontalMove, verticalMove).normalized * Time.deltaTime * speedMove;

        //Limita el rango de movimiento
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Enemy"))
        {
            receiveDamage(5);
            Destroy(other.gameObject);
            if (currentLife <= 0) 
            {
                GameOverPanel.GameOver(points);
            }
        }
        
    }

    private void receiveDamage(float damage)
    {
        currentLife -= damage;
        barLife.UpdateBarLife(currentLife, life);
    }
}
