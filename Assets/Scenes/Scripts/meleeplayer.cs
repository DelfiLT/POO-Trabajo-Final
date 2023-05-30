using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeplayer : Heroes
{

    void Start()
    {
    }

    void Update()
    {
        Movement();
    }

    protected override void Movement()
    {
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0.01f * velocity, 0);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-0.01f * velocity, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, -0.01f * velocity, 0);
        if (Input.GetKey(KeyCode.D)) transform.Translate(0.01f * velocity, 0, 0);
    }
}
