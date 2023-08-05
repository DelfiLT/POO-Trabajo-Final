using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lance : MonoBehaviour
{
    public int lanceDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IgetEnemyDamaged>() != null)
        {
            collision.gameObject.GetComponent<IgetEnemyDamaged>().GetEnemyDamage(lanceDamage);
        }
    }
}
