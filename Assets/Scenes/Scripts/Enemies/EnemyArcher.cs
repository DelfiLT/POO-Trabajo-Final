using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyArcher : Enemies
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
        distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);


        if (distanceFromPlayer1 < lineOfSite && distanceFromPlayer1 > shootingRange && distanceFromPlayer1 < distanceFromPlayer2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player1Transform.position, velocity * Time.deltaTime);
        }
        else if (distanceFromPlayer1 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (distanceFromPlayer2 < lineOfSite && distanceFromPlayer2 > shootingRange && distanceFromPlayer2 < distanceFromPlayer1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player2Transform.position, velocity * Time.deltaTime);
        }
        else if (distanceFromPlayer2 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
}
