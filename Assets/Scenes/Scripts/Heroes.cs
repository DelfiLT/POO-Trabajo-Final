using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroes : MonoBehaviour
{
    [SerializeField] protected int lifeQuantity;
    [SerializeField] protected float velocity;
    [SerializeField] protected float damage;

    protected Animator Anim;
    protected Rigidbody2D Rb;

    public Vector2 mov;

    protected virtual void Attack() { }
    protected virtual void Die() 
    {
        if (lifeQuantity == 0)
        {
            Debug.Log("Die");
        }
    }
    protected virtual void Revive() { }
    protected virtual void Pick() { }

    protected virtual void Movement() 
    {
        Rb.MovePosition(Rb.position + velocity * Time.deltaTime * mov);
    }
}
