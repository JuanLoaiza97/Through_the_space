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

    public Sprite staticShip;
    public Sprite movingShip;

    private void Start()
    {
        currentLife = life;
    }

    private void Update()
    {
        Move();
    }

    //RF2 (Movimiento jugador)
    private void Move()
    {
        //Captura la posicion de joystick en ambos ejes, que va desde -1 a 1
        float verticalMove = joystick.Vertical;
        float horizontalMove = joystick.Horizontal;

        if (verticalMove != 0 && horizontalMove != 0) 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = movingShip;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = staticShip;
        }

        /*A la posicion actual se le suma un vector en base a la posicion del joystick.
         *Normalized se usa para que el movimiento en diagonal sea igual al movimiento en los ejes x,y.
         *Se multiplica por speed para ir más rapido o lento
         *Time.deltaTime se usa para el juego corra igual, sin importar la velocidad del dispositivo
         */
        transform.position += new Vector3(horizontalMove, verticalMove).normalized * Time.deltaTime * speedMove;

        //Limita el rango de movimiento
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //RF1 Recibir daño si choca con un enemigo
        if (other.collider.CompareTag("Enemy"))
        {
            SoundController.instance.PlayCollisionSound();
            other.gameObject.GetComponent<EnemyObject>().Destroy();
            ReceiveDamage(other.gameObject.GetComponent<EnemyObject>().damage);
            if (currentLife <= 0) 
            {
                SoundController.instance.PlayGameOverSound();
                levelController.GameOver(points);
            }
        }
        //RNF3 Curarse
        else if (other.collider.CompareTag("FistAidKit"))
        {
            SoundController.instance.PlayFirstAidKitSound();
            Destroy(other.gameObject);
            Heal(other.gameObject.GetComponent<FirstAidKit>().healing);
        }
        //RF5 Pasar al siguiente nivel
        else if (other.collider.CompareTag("Portal"))
        {
            SoundController.instance.PlayTeleportationSound();
            //levelController.NextLevel();
        }
        else if (other.collider.CompareTag("Coin"))
        {
            SoundController.instance.PlayCoinSound();
            Destroy(other.gameObject);
            AddPoints(other.gameObject.GetComponent<Coin>().points);
        }
        
    }


    private void ReceiveDamage(float damage)
    {
        currentLife -= damage;
        //RF1 Actualizar barra de vida al recibir daño
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

    private void AddPoints(int points)
    {
        this.points += points;
        levelController.UpdateScoreIndicator();
    }
}
