using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NPC Scriptable", menuName = "NPCMenu")]
public class scriptableNPC : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private string[] dialogs;
    [SerializeField] private TextMeshProUGUI dialog;

    public int HP { get { return hp; } }
    public string[] Dialogs { get { return dialogs; } }
    public TextMeshProUGUI Dialog { get { return dialog; } }

    public void Talk()
    {
        dialog = GameObject.FindGameObjectWithTag("npcDialog").GetComponent<TextMeshProUGUI>();
        dialog.text = dialogs[Random.Range(0, dialogs.Length)];
    }

    public void GetDamage()
    {
        hp = hp - 1;
    }

}
