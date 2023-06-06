using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lance : MonoBehaviour
{
    [SerializeField] private Transform lanceDirection;
    [SerializeField] private Transform lanceSpawn;

    private meleeplayer meleeScript;

    private void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player1");
        if (PlayerObject != null)
        {
            meleeScript = PlayerObject.GetComponent<meleeplayer>();
        }
    }

    private void Update()
    {
        lanceDirection.transform.position = new Vector2(
            meleeScript.transform.position.x + meleeScript.Mov.x * 1.5f,
            meleeScript.transform.position.y + meleeScript.Mov.y * 1.5f
            );
        if ( meleeScript.Mov != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(lanceDirection.forward, -meleeScript.Mov);
            lanceDirection.transform.rotation = toRotation;
        } 
    }
}
