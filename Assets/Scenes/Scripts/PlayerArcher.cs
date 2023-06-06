using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes
{
    Animator archerAnimator;

    public int movX;
    public int movY;

    // Start is called before the first frame update
    void Start()
    {
        archerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        archerAnimator.SetFloat("MovX", movX);
        archerAnimator.SetFloat("MovY", movY);
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
