using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public int arrowDamage = 1;

    void Update()
    {
        this.transform.Translate(Vector2.up * speedArrow * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IgetEnemyDamaged>() != null)
        {
            collision.gameObject.GetComponent<IgetEnemyDamaged>().GetEnemyDamage(arrowDamage);
        }
    }
}
