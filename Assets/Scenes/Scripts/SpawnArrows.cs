using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnArrows : MonoBehaviour
{
    public float arrowSpeed;
    public GameObject arrowPrefab;
    public Transform SpawnPosition;

    [SerializeField] private Transform bowDirection;
    [SerializeField] private Transform bowSpawn;

    private PlayerArcher archerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            //GameObject newArrow = Instantiate(arrowPrefab, Quaternion.LookRotation(bowDirection.forward, -archerScript.Mov));
            //GameObject newArrow = Instantiate(arrowPrefab, SpawnPosition.position, Quaternion.Euler(0,0,0));
            GameObject newArrow = Instantiate(arrowPrefab, SpawnPosition.position, SpawnPosition.rotation);// * Quaternion.Euler(0f, 0f, 90f));
            //for (int i = 0; i < 100; i++)
            //{
            //    GameObject newArrow = Instantiate(arrowPrefab);
            //   Position2 = newArrow.gameObject.transform.position = Vector3.zero;
            //    newArrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            //}
        }
        
    }
}
