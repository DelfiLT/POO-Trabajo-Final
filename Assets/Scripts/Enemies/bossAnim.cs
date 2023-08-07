using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAnim : Enemies
{
    private void Start()
    {
        FindPlayer();
        AnimEnemy = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player1Transform != null)
        {
            distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        }
        if (player2Transform != null)
        {
            distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);
        }

        if (distanceFromPlayer1 > minRange && distanceFromPlayer1 < range && distanceFromPlayer1 < distanceFromPlayer2 && player1Transform != null)
        {
            AnimEnemy.SetTrigger("walk");
        }
        if (distanceFromPlayer2 > minRange && distanceFromPlayer2 < range && distanceFromPlayer2 < distanceFromPlayer1 && player2Transform != null)
        {
            AnimEnemy.SetTrigger("walk");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            AnimEnemy.SetTrigger("attack");
        }
    }
}
