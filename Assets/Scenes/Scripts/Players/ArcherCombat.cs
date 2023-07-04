using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherCombat : MonoBehaviour
{
    [SerializeField] private Transform bowDirection;
    [SerializeField] private Transform bowSpawn;

    private PlayerArcher archerScript;

    private void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player2");
        if (PlayerObject != null)
        {
            archerScript = PlayerObject.GetComponent<PlayerArcher>();
        }
    }

    private void Update()
    {
        bowDirection.transform.position = new Vector2(
            archerScript.transform.position.x + archerScript.Mov.x * 1f,
            archerScript.transform.position.y + archerScript.Mov.y * 1f
            );
        if (archerScript.Mov != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(bowDirection.forward, -archerScript.Mov);
            bowDirection.transform.rotation = toRotation;
        }
    }
}
