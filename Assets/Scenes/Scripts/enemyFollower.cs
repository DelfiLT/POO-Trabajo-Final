using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollower : Enemies
{
    [SerializeField] protected float range;
    protected float distanceFromPlayer1;
    protected float distanceFromPlayer2;
    protected Transform player1Transform;
    protected Transform player2Transform;

    protected virtual void FindPlayer()
    {
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;
        player2Transform = GameObject.FindGameObjectWithTag("Player2").transform;
    }
    protected virtual void FollowPlayer() 
    {
        distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);

        if (distanceFromPlayer1 < range && distanceFromPlayer1 < distanceFromPlayer2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player1Transform.position, velocity * Time.deltaTime);
        }
        if (distanceFromPlayer2 < range && distanceFromPlayer2 < distanceFromPlayer1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player2Transform.position, velocity * Time.deltaTime);
        }
    }
}
