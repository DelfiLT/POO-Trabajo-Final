using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speedArrow;
    public Transform arrow;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, arrow.position);

 //       rotating();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.up * speedArrow * Time.deltaTime);
        
        Destroy(gameObject, 0.5f);
    }

    void rotating()
    {
        transform.Rotate(0, 0, 90);
    }
}
