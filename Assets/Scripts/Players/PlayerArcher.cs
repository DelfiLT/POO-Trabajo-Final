using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes, Iobject, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    private Arrow arrowScript;

    public static event Action<string> onSceneChange;

    public GameObject damageScrollUI;
    public GameObject velocityScrollUI;

    void Start()
    {
        arrowScript = GameObject.FindGameObjectWithTag("Arrow")?.GetComponent<Arrow>();
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
            StartCoroutine(activeVelBoost());
        }
        if(objectName == "damage")
        {
            StartCoroutine(activeDmgBoost());
        }
    }

    public void deathScreen()
    {
        if (hp == 0 && lifeQuantity > 0)
        {
            onSceneChange?.Invoke("revivePanelP2");
        }

        if (hp > 0)
        {
            onSceneChange?.Invoke("disRevivePanelP2");
        }

        if (hp == 0 && lifeQuantity == 0)
        {
            onSceneChange?.Invoke("deathPanelP2");
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

    IEnumerator activeDmgBoost()
    {
        damageScrollUI.SetActive(true);
        arrowScript.arrowDamage++;
        yield return new WaitForSeconds(10f);
        damageScrollUI.SetActive(false);
        arrowScript.arrowDamage--;
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
