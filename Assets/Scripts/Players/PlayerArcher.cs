using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerArcher : Heroes, Iobject, IgetDamagedInterface
{
    public Vector2 Mov { get { return mov; } }
    public int HP { get { return hp; } }
    private Arrow arrowScript;

    public static event Action<string> onSceneChange;
    public static event Action<string> onUIP2Change;
    public static event Action<string> onHpChange;
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
        UIManager();
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

    public void UIManager()
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
        if (hp == 12)
        {
            onHpChange?.Invoke("FULLHP2");
        }

        if (hp == 8)
        {
            onHpChange?.Invoke("1HP2");
        }

        if (hp == 4)
        {
            onHpChange?.Invoke("2HP2");
        }

        if (hp == 0)
        {
            onHpChange?.Invoke("3HP2");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Heroes>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Revive();
                onHpChange?.Invoke("FULLHP2");
            }
        }
    }
    IEnumerator activeDmgBoost()
    {
        onUIP2Change?.Invoke("damageScrollP2");
        arrowScript.arrowDamage++;
        yield return new WaitForSeconds(10f);
        onUIP2Change?.Invoke("disDamageScrollP2");
        arrowScript.arrowDamage--;
    }

    IEnumerator activeVelBoost()
    {
        onUIP2Change?.Invoke("velocityScrollP2");
        velocity = velocity * 1.2f;
        yield return new WaitForSeconds(10f);
        onUIP2Change?.Invoke("disVelocityScrollP2");
        velocity = velocity / 1.2f;
    }
}
