using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private scriptableNPC npcData;
    private int hp = 1000;
    public string[] dialogs;
    public TextMeshProUGUI dialog;
    private float timeMax;
    private float time;

    void Start()
    {
        dialogs = npcData.Dialogs;
        timeMax = npcData.TimeMax;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > timeMax) 
        {
            StartCoroutine(deleteDialog());
            time = 0;
        } 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hp = hp--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyFlyer"))
        {
            hp = hp--;
        }
    }

    IEnumerator deleteDialog ()
    {
        dialog.text = npcData.Talk();
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }

}
