using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanceee : MonoBehaviour
{
    private Animator lanceAnim;

    void Start()
    {
        lanceAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            lanceAnim.SetTrigger("attack");
        }
        //if (Input.GetKeyUp(KeyCode.G))
        //{
        //    lanceAnim.SetBool("Attack", false);
        //}

    }
}
