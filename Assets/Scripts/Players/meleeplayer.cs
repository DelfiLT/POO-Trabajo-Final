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
    public static event Action<string> onUIP1Change;
    public static event Action<string> onHpChange;

    public GameObject lance;

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
        UIManager();
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

    public void UIManager()
    {
        if(hp <= 0 && lifeQuantity > 0)
        {
            onSceneChange?.Invoke("revivePanelP1");
        }

        if (hp > 0)
        {
            onSceneChange?.Invoke("disRevivePanelP1");
        }

        if (hp <= 0 && lifeQuantity == 0)
        {
            onSceneChange?.Invoke("deathPanelP1");  
        }

        if(hp == 12)
        {
            onHpChange?.Invoke("FULLHP1");
        }

        if(hp == 8)
        {
            onHpChange?.Invoke("1HP1");
        }

        if(hp == 4)
        {
            onHpChange?.Invoke("2HP1");
        }

        if(hp == 0)
        {
            onHpChange?.Invoke("3HP1");
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
        onUIP1Change?.Invoke("damageScrollP1");
        lanceScript.lanceDamage++;
        yield return new WaitForSeconds(10f);
        onUIP1Change?.Invoke("disDamageScrollP1");
        lanceScript.lanceDamage--;
    }

    IEnumerator activeVelBoost()
    {
        onUIP1Change?.Invoke("velocityScrollP1");
        velocity = velocity * 1.2f;
        yield return new WaitForSeconds(10f);
        onUIP1Change?.Invoke("disVelocityScrollP1");
        velocity = velocity / 1.2f;
    }
}
