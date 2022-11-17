using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabrielon : MonoBehaviour
{
    public LevelController levelController;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private ProgressBar levelProgressBar;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Transform[] pointsMovement;
    [SerializeField] private float heal;
    [SerializeField] private float speedMovement;
    [SerializeField] private float minDistance;
    [SerializeField] private float timeRateToAttack;
    [SerializeField] private float damageAttack;
    private GameObject spaceship;
    private SpriteRenderer spriteRenderer;
    private Vector3 randomPoint;
    private float healTotal;
    private float speed;
    private float timeToAttack;
    private bool isAttack;
    private float time;
    private int state;
    private Animator animator;
    

    private void Start()
    {
        levelProgressBar.UpdateBar(0, 1);
        healTotal = heal;
        randomPoint = pointsMovement[Random.Range(0, pointsMovement.Length)].position;
        speed = speedMovement;
        timeToAttack = timeRateToAttack;
        spriteRenderer = GetComponent<SpriteRenderer>();
        state = 1;

        animator = GetComponent<Animator>();
        spaceship = GameObject.FindGameObjectWithTag("Player");
        spaceship.GetComponent<Spaceship>().attackButton.SetActive(false);
    }


    private void Update()
    {
        time += Time.deltaTime;

        InitScene();

        if (state == 5)
        {
            Move();

            if (!isAttack && timeToAttack <= time)
            {
                isAttack = true;
                animator.SetTrigger("Attack");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        heal -= damage;
        levelProgressBar.UpdateBar(healTotal - heal, healTotal);
        if (heal < 0)
        {
            Defeat();
        }
    }

    private void Defeat()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        levelController.FinishLevel();
        SoundController.instance.SetBackgroundMusic(SoundController.instance.win);
        Destroy(gameObject);
    }


    //Animacion de entrada de gabrielon
    private void InitScene()
    {
        if (time < 3)
        {
            return;
        }

        if (state == 1)
        {
            //Musica de fondo
            SoundController.instance.SetBackgroundMusic(SoundController.instance.gabrielon);
            state = 2;
            return;
        }

        if (time > 6 && state == 2)
        {
            //Aparece gabrielon
            animator.SetTrigger("Appearing");
            SoundController.instance.PlayAppearingGabrielonSound();
            state = 3;
            return;
        }

        if (time > 9 && state == 3)
        {
            //Se rie gabrielon
            SoundController.instance.PlayEvilLaughterSound();
            state = 4;
            return;
        }

        if (time > 13 && state == 4)
        {
            //Inicia el combate
            timeToAttack = time + timeRateToAttack;
            animator.SetTrigger("Move");
            SoundController.instance.SetBackgroundMusic(SoundController.instance.gabrielonCombat);
            state = 5;
            spawnObject.SetActive(true);
            spaceship.GetComponent<Spaceship>().attackButton.SetActive(true);
            return;
        }

    }

    //Movimiento normal de gabrielon
    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, randomPoint) < minDistance)
        {
            randomPoint = pointsMovement[Random.Range(0, pointsMovement.Length)].position;

            if (isAttack)
            {
                isAttack = false;
                timeToAttack = time + timeRateToAttack;
            }
        }
    }

    //Calcula el punto hacia donde debe atacar
    public Vector3 GetPointAttack()
    {
        return new Vector3(-6, spaceship.transform.position.y, spaceship.transform.position.z);
    }

    public float GetSpeedMovement()
    {
        return speedMovement;
    }


    //Moverse a la esecena
    public void Appearing()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsMovement[0].position, speed * Time.deltaTime);
    }

    //Atacar
    private void Attack()
    {
        SoundController.instance.PlayEvilLaughterSound();
        isAttack = true;
        randomPoint = GetPointAttack();
        speed = speedMovement * 4;
    }

    //Inflijir daño
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Instantiate(explosionEffect, other.gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Spaceship>().ReceiveDamage(damageAttack);
        }
    }
}
