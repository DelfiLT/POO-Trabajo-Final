using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NPC Scriptable", menuName = "NPCMenu")]
public class scriptableNPC : ScriptableObject
{
    [SerializeField] private string[] dialogs;
    [SerializeField] private int timeMax;

    public string[] Dialogs { get { return dialogs; } }
    public int TimeMax { get {  return timeMax; } }


    public string  Talk()
    {
        return dialogs[Random.Range(0, dialogs.Length)];
    }
}
