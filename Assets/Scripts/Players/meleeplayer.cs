 using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeplayer : Heroes, Iobject, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    public Animator lanceAnim;
    
    public int lanceDamage = 1;

    public GameObject lance;
    public GameObject deathPanel;
    public GameObject revivePanel;
    public GameObject damageScrollUI;
    public GameObject velocityScrollUI;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        lance = GameObject.FindGameObjectWithTag("lance");
        lanceAnim = GameObject.FindGameObjectWithTag("lance").GetComponent<Animator>();
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
        deathScreen();
    }

    public void GetDamaged(int damage)
    {
        hp -=  damage;
    }

    public void PickObject(string objectName)
    {
        if(objectName == "life")
        {
            hp = hp + 5;
        }
        if(objectName == "velocity")
        {
            velocityScrollUI.SetActive(true);
            velocity = velocity * 1.2f;
        }
        if(objectName == "damage")
        {
            damageScrollUI.SetActive(true);
            lanceDamage++;
        }
    }

    public void deathScreen()
    {
        if(hp == 0 && lifeQuantity > 0)
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
        if(collision.gameObject.GetComponent<Heroes>())
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                Revive();
            }
        }
    }

}
