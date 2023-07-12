using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyArcher : Enemies, IgetEnemyDamaged
{
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;

    void Start()
    {
       FindPlayer();
    }

    void Update()
    {
        if (player1Transform != null)
        {
            distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        }
        if (player2Transform != null)
        {
            distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);
        }

        if (distanceFromPlayer1 < lineOfSite && distanceFromPlayer1 > shootingRange && distanceFromPlayer1 < distanceFromPlayer2 && player1Transform != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player1Transform.position, velocity * Time.deltaTime);
        }
        else if (distanceFromPlayer1 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (distanceFromPlayer2 < lineOfSite && distanceFromPlayer2 > shootingRange && distanceFromPlayer2 < distanceFromPlayer1 && player2Transform != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player2Transform.position, velocity * Time.deltaTime);
        }
        else if (distanceFromPlayer2 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FixedUpdate()
    {
        Die();
    }

    public void GetEnemyDamage(int damage)
    {
        hp -= damage;
    }

    protected override void Die()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
