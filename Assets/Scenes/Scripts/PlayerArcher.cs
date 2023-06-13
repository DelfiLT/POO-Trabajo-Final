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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("press P");
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
        //lance.Translate(new Vector2(lance.position.x + 1, lance.position.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeQuantity--;
        }
    }
}
