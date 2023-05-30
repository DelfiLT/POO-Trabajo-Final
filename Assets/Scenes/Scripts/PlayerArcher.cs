using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcher : Heroes
{
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    protected override void Movement()
    {
        if (Input.GetKey(KeyCode.W)) transform.Translate(0, 0.01f * velocity, 0);
        if (Input.GetKey(KeyCode.A)) transform.Translate(-0.01f * velocity, 0, 0);
        if (Input.GetKey(KeyCode.S)) transform.Translate(0, -0.01f * velocity , 0);
        if (Input.GetKey(KeyCode.D)) transform.Translate(0.01f * velocity , 0, 0);
    }
}
