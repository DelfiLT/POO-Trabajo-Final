using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, Idialog
{
    [SerializeField] private scriptableNPC npcData;
    public int hp;
    public string[] dialogs;
    public TextMeshProUGUI dialog;

    void Start()
    {
        hp = npcData.HP;
        dialogs = npcData.Dialogs;
        dialog = npcData.Dialog;
    }

    private void Update()
    {
        InvokeRepeating("Action", 1f, 3f);
    }

    public void Action() 
    {
        npcData.Talk();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            npcData.GetDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyFlyer"))
        {
            npcData.GetDamage();
        }
    }
}
