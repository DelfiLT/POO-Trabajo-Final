using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected int lifeQuantityEnemy;
    [SerializeField] protected float velocityEnemy;
    [SerializeField] protected float damageEnemy;

    protected Animator AnimEnemy;
    protected Rigidbody2D RbEnemy;

    protected virtual void AttackPlayer() { }
    protected virtual void DieEnemy()
    {
        if (lifeQuantityEnemy == 0)
        {
            Debug.Log("Enemy has died");
        }
    }
}
