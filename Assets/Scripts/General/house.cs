using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    public Transform tp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = tp.position;
    }
}
