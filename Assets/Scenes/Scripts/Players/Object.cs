using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string objectName;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("tocando");
        //if(collision.gameObject.CompareTag("Player1") && collision.gameObject.GetComponent<Iobject>() != null)
        //{
        //    if(Input.GetKeyDown(KeyCode.E))
        //    {
        //        collision.gameObject.GetComponent<Iobject>().PickObject(objectName);
        //        Destroy(this.gameObject);
        //    }
        //}
        //if (collision.gameObject.CompareTag("Player2") && collision.gameObject.GetComponent<Iobject>() != null)
        //{
        //    if (Input.GetKeyDown(KeyCode.O))
        //    {
        //        collision.gameObject.GetComponent<Iobject>().PickObject(objectName);
        //        Destroy(this.gameObject);
        //    }
        //}

        if(collision.gameObject.GetComponent<Iobject>() != null)
        {
            collision.gameObject.GetComponent<Iobject>().PickObject(objectName);
            Destroy(this.gameObject);
        }
    }
}
