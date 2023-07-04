using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public Transform arrow;

    void Update()
    {
        transform.Translate(Vector2.up * speedArrow * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }
}
