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
    protected Transform player1Transform;
    protected Transform player2Transform;


    // Start is called before the first frame update
    void Start()
    {
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;
        player2Transform = GameObject.FindGameObjectWithTag("Player2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        float distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);


        if (distanceFromPlayer1 < lineOfSite && distanceFromPlayer1 > shootingRange && distanceFromPlayer1 < distanceFromPlayer2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player1Transform.position, velocityEnemy * Time.deltaTime);
        }
        else if (distanceFromPlayer1 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

        if (distanceFromPlayer2 < lineOfSite && distanceFromPlayer2 > shootingRange && distanceFromPlayer2 < distanceFromPlayer1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player2Transform.position, velocityEnemy * Time.deltaTime);
        }
        else if (distanceFromPlayer2 <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
}
