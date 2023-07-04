using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes, Iobject
{
    public Vector2 Mov { get { return mov; } }
    public int movX;
    public int movY;
    public int arrowDamage = 1;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal_P2"), Input.GetAxisRaw("Vertical_P2"));
        Anim.SetFloat("movX", mov.x);
        Anim.SetFloat("movY", mov.y);
        mov.Normalize();
    }

    private void FixedUpdate()
    {
        Movement();
        Die();
    }

    public void PickObject(string objectName)
    {
        if (objectName == "life")
        {
            hp = hp + 5;
        }
        if (objectName == "velocity")
        {
            velocity = velocity * 1.2f;
        }
        if(objectName == "damage")
        {
            arrowDamage++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemies>())
        {
            hp--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemies>())
        {
            hp--;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Heroes>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Revive();
            }
        }
    }
}
