using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroes : MonoBehaviour
{
    public int lifeQuantity;
    public float velocity;
    public float damage;

    protected virtual void Attack() { }
    protected virtual void Die() { }
    protected virtual void Revive() { }
    protected virtual void Movement() { }
    protected virtual void Pick() { }
}
