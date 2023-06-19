using UnityEngine;

public class enemyFlyer : enemyFollower
{
    void Start()
    {
        FindPlayer();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FixedUpdate()
    {
        Die();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
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
