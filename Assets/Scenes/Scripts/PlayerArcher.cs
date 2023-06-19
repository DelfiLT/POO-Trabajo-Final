using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes
{
    Animator archerAnimator;
    public Vector2 Mov { get { return mov; } }

    public int movX;
    public int movY;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeQuantity--;
        }
    }
}
