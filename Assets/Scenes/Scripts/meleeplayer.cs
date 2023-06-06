using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meleeplayer : Heroes
{
    private Animator ninjaAnim;
    public int movX;
    public int movY;

    void Start()
    {
        ninjaAnim = GetComponent<Animator>();
    }

    void Update()
    {
        ninjaAnim.SetFloat("movX", movX);
        ninjaAnim.SetFloat("movY", movY);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    protected override void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movY = 1;
            transform.Translate(0, 0.01f * velocity, 0);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            movX = -1;
            transform.Translate(-0.01f * velocity, 0, 0);
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            movY = -1;
            transform.Translate(0, -0.01f * velocity, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movX = 1;
            transform.Translate(0.01f * velocity, 0, 0);
        }
    }
}
