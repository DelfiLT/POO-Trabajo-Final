using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletEnemyArcher : MonoBehaviour
{
    public Transform player1Transform;
    public Transform player2Transform;

    public float speedBullet;
    public int damage = 1;

    Rigidbody2D bulletRB;

    public GameObject particles;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player1Transform = GameObject.FindGameObjectWithTag("Player1").transform;
        player2Transform = GameObject.FindGameObjectWithTag("Player2").transform;

        float distanceFromPlayer1 = Vector2.Distance(player1Transform.position, transform.position);
        float distanceFromPlayer2 = Vector2.Distance(player2Transform.position, transform.position);

        if (distanceFromPlayer1 < distanceFromPlayer2)
        {
            Vector2 moveDir = (player1Transform.transform.position - transform.position).normalized * speedBullet;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject, 2);
        }

        if (distanceFromPlayer2 < distanceFromPlayer1)
        {
            Vector2 moveDir = (player2Transform.transform.position - transform.position).normalized * speedBullet;
            bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
            Destroy(this.gameObject, 2);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IgetDamagedInterface>() != null)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<IgetDamagedInterface>().GetDamaged(damage);
        }
    }
}
