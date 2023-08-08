using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    private meleeplayer meleePlayer;
    private PlayerArcher archerPlayer;
    private enemyFollow boss;
    public TextMeshProUGUI enemyCountUI;
    public GameObject level1EnemiesFather;
    public BoxCollider2D level2Coll;
    
    public int enemyCount;
    public int level1EnemiesQuantity;

    public int meleeHp;
    public int archerHp;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss")?.GetComponent<enemyFollow>();
        meleePlayer = GameObject.FindGameObjectWithTag("Player1")?.GetComponent<meleeplayer>();
        archerPlayer = GameObject.FindGameObjectWithTag("Player2")?.GetComponent<PlayerArcher>();

        enemyCount = 0;
        level1EnemiesQuantity = level1EnemiesFather.transform.childCount;
    }

    void Update()
    {
        meleeHp = meleePlayer.HP;
        archerHp = archerPlayer.HP;

        if (meleeHp == 0 && archerHp == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        enemyCountUI.text = enemyCount.ToString("0") + "/" + level1EnemiesQuantity;

        if(enemyCount == level1EnemiesQuantity)
        {
            Debug.Log("ACTIVATE LEVEL 1 SCREEN");
            level2Coll.enabled = false;
        }

        if(boss.HP == 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
