using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletEnemyflying : MonoBehaviour
{
    private Transform Playerposition;

    private PlayerArcher player;

    public GameObject target;

    public float speedBullet;

    Rigidbody2D bulletRB;


    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player2");
        Vector2 moveDir = (target.transform.position -transform.position).normalized * speedBullet;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
