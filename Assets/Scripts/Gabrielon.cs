using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabrielon : MonoBehaviour
{
    [SerializeField] private GameObject spaceship;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private Transform[] pointsMovement;
    [SerializeField] private float speedMovement;
    [SerializeField] private float minDistance;
    [SerializeField] private float timeRateToAttack;
    [SerializeField] private float damageAttack;
    private SpriteRenderer spriteRenderer;
    private Vector3 randomPoint;
    private float speed;
    private float timeToAttack;
    private bool isAttack;
    private float time;

    [Header("Laser")]
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lineRenderer;

    private void Start()
    {
        randomPoint = pointsMovement[Random.Range(0, pointsMovement.Length)].position;
        speed = speedMovement;
        timeToAttack = timeRateToAttack;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        time += Time.deltaTime;

        Move();
        
        if (!isAttack && timeToAttack <= time)
        {
            timeToAttack = time + timeRateToAttack;
            Attack();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, randomPoint) < minDistance)
        {
            randomPoint = pointsMovement[Random.Range(0, pointsMovement.Length)].position;

            if (isAttack)
            {
                isAttack = false;
                speed = speedMovement;
            }
        }
    }

    private void Turn()
    {
        if (transform.position.x < randomPoint.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void Attack()
    {
        isAttack = true;
        randomPoint = spaceship.transform.position;
        speed = speedMovement * 4;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Instantiate(explosionEffect, other.gameObject.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Spaceship>().ReceiveDamage(damageAttack);
        }
    }

        private void ShootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
            Draw2DRay(laserFirePoint.position, hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
