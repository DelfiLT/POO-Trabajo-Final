using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherCombat : MonoBehaviour
{
    [SerializeField]
    private Transform weaponDirection;

    private PlayerArcher archerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        if(PlayerObject != null)
        {
            archerScript = PlayerObject.GetComponent<PlayerArcher>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        weaponDirection.transform.position = new Vector2(
            archerScript.transform.position.x + archerScript.movX / 2,
            archerScript.transform.position.x + archerScript.movY / 2);

      // if(archerScript.)
    }
}
