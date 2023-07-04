using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroes : MonoBehaviour
{
    [SerializeField] protected int hp;
    [SerializeField] protected float velocity;
    [SerializeField] protected int lifeQuantity = 3;
    [SerializeField] protected bool canRevive = false;

    protected Animator Anim;
    protected Rigidbody2D Rb;

    public Vector2 mov;

    protected virtual void Die()
    {
        if (lifeQuantity > 0)
        {
            lifeQuantity--;
            velocity = 0;
            Debug.Log("Mostrar pantalla roja");
        }
    }
    protected virtual void Revive() { }
    protected virtual void Pick() { }

    protected virtual void Movement()
    {
        Rb.MovePosition(Rb.position + velocity * Time.deltaTime * mov);
    }
}
