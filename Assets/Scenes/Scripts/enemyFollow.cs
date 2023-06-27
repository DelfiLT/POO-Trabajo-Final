using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : Enemies
{
    void Start()
    {
        FindPlayer();
    }

    void Update()
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

    private void FixedUpdate()
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lance"))
        {
            lifeQuantity--;
        }
    }

    protected override void Die()
    {
        if (lifeQuantity == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
