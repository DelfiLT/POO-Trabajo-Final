using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes, Iobject, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    public int movX;
    public int movY;
    public int arrowDamage = 1;
    public GameObject deathPanel;
    public GameObject revivePanel;

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
        deathScreen();
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
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

    public void deathScreen()
    {
        if (hp == 0 && lifeQuantity > 0)
        {
            revivePanel.SetActive(true);
        }

        if (hp > 0)
        {
            revivePanel.SetActive(false);
        }

        if (hp == 0 && lifeQuantity == 0)
        {
            deathPanel.SetActive(true);
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
