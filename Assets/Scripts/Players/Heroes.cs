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
        if(lifeQuantity > 0 && hp <= 0)
        {
            canRevive = true;
        }

        if(hp > 0)
        {
            canRevive = false;
        }

        if(hp <= 0 && canRevive)
        {
            velocity = 0;
            Rb.mass = 99999;

        }

        if (hp <= 0 && lifeQuantity <= 0)
        {
            canRevive = false;
            Destroy(this.gameObject);
        }
    }

    protected virtual void Revive() 
    {
        if(canRevive)
        {
            lifeQuantity--;
            hp = 10;
            velocity = 10;
            Rb.mass = 2000;
            
        }
    }

    protected virtual void Movement()
    {
        Rb.MovePosition(Rb.position + velocity * Time.deltaTime * mov);
    }
}
