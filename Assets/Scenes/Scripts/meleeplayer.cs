 using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeplayer : Heroes, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    public GameObject lance;
    public Animator lanceAnim;

    void Start()
    {
        lance = GameObject.FindGameObjectWithTag("lance");
        lanceAnim = GameObject.FindGameObjectWithTag("lance").GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        lance.SetActive(false);
    }

    void Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal_P1"), Input.GetAxisRaw("Vertical_P1"));
        Anim.SetFloat("movX", mov.x);
        Anim.SetFloat("movY", mov.y);

        lanceAnim.SetFloat("movX", mov.x);
        lanceAnim.SetFloat("movY", mov.y);

        mov.Normalize();

        if (Input.GetKeyDown(KeyCode.G))
        {
            lance.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            lance.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemies>())
        {
            lifeQuantity--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemies>())
        {
            lifeQuantity--;
        }
    }
}
