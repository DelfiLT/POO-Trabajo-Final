 using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeplayer : Heroes
{
    public Vector2 Mov { get { return mov; } }
    public Transform lance;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal_P1"), Input.GetAxisRaw("Vertical_P1"));
        Anim.SetFloat("movX", mov.x);
        Anim.SetFloat("movY", mov.y);
        mov.Normalize();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("press g");
            Attack();
        }
    }

    private void FixedUpdate()
    {
        Movement();

        Die();
    }

    protected override void Attack()
    {
       lance.Translate(new Vector2(lance.position.x + 1, lance.position.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeQuantity--;
        }
    }
}
