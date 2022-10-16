using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public LevelController levelController;

    [Header("Life")]
    public ProgressBar barLife;
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
            Destroy(other.gameObject);
            ReceiveDamage(other.gameObject.GetComponent<EnemyObject>().damage);
            if (currentLife <= 0) 
            {
                levelController.GameOver(points);
            }
        }
        else if (other.collider.CompareTag("FistAidKit"))
        {
            Destroy(other.gameObject);
            Heal(other.gameObject.GetComponent<FirstAidKit>().healing);
        }
        else if (other.collider.CompareTag("Portal"))
        {
            levelController.NextLevel();
        }
        
    }

    private void ReceiveDamage(float damage)
    {
        currentLife -= damage;
        barLife.UpdateBar(currentLife, life);
    }

    private void Heal(float healing)
    {
        currentLife += healing;
        if (currentLife > life) 
        {
            currentLife = life;
        }
        barLife.UpdateBar(currentLife, life);
    }
}
