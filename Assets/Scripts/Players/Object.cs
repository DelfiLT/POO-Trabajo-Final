using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string objectName;

    private void OnCollisionStay2D(Collision2D collision)
    {
       
        if(collision.gameObject.GetComponent<Iobject>() != null)
        {
            collision.gameObject.GetComponent<Iobject>().PickObject(objectName);
            Destroy(this.gameObject);
        }
    }
}
