 using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeplayer : Heroes, Iobject, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    public Animator lanceAnim;
    
    public lance lanceScript;

    public static event Action<string> onSceneChange;

    public GameObject lance;
    public GameObject damageScrollUI;
    public GameObject velocityScrollUI;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        lance = GameObject.FindGameObjectWithTag("lance");
        lanceScript = GameObject.FindGameObjectWithTag("lance")?.GetComponent<lance>();
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
            StartCoroutine(activeVelBoost());
        }
        if(objectName == "damage")
        {
            StartCoroutine(activeDmgBoost());
        }
    }

    public void deathScreen()
    {
        if(hp == 0 && lifeQuantity > 0)
        {
            onSceneChange?.Invoke("revivePanelP1");
        }

        if (hp > 0)
        {
            onSceneChange?.Invoke("disRevivePanelP1");
        }

        if (hp == 0 && lifeQuantity == 0)
        {
            onSceneChange?.Invoke("deathPanelP1");  
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

    IEnumerator activeDmgBoost()
    {
        damageScrollUI.SetActive(true);
        lanceScript.lanceDamage++;
        yield return new WaitForSeconds(10f);
        damageScrollUI.SetActive(false);
        lanceScript.lanceDamage--;
    }

    IEnumerator activeVelBoost()
    {
        velocityScrollUI.SetActive(true);
        velocity = velocity * 1.2f;
        yield return new WaitForSeconds(10f);
        velocityScrollUI.SetActive(false);
        velocity = velocity / 1.2f;
    }
}
