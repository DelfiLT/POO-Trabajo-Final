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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject newArrow = Instantiate(arrowPrefab, SpawnPosition.position, SpawnPosition.rotation);
        }
    }
}
