using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] protected int lifeQuantity;
    [SerializeField] protected float velocity;

    protected Animator AnimEnemy;
    protected virtual void Die() { }
}
