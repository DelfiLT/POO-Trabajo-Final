using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lance : MonoBehaviour
{
    [SerializeField]
    private meleeplayer meleeScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        if (PlayerObject != null)
        {
            meleeScript = PlayerObject.GetComponent<meleeplayer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(meleeScript.movX == 1)
        {
            transform.position = new Vector2(0.105f, -0.05f);
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if (meleeScript.movX == -1)
        {
            transform.position = new Vector2(-0.105f, -0.05f);
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        if (meleeScript.movY == 1)
        {
            transform.position = new Vector2(-0.06f, -0.05f);
            transform.localScale = new Vector2(0.8f, -0.8f);
        }
        if (meleeScript.movY == -1)
        {
            transform.position = new Vector2(-0.06f, -0.13f);
            transform.localScale = new Vector2(0.8f, 0.8f);
        }
    }
}
