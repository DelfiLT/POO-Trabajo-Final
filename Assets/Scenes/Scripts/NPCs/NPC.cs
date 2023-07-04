using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, IgetDamagedInterface
{
    [SerializeField] private scriptableNPC npcData;
    private int hp = 1;
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


    IEnumerator deleteDialog ()
    {
        dialog.text = npcData.Talk();
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
        if (hp <= 0) { Debug.Log("Villager death"); }
    }
}
