using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    public GameObject damageScrollP1;
    public GameObject velocityScrollP1;
    public GameObject damageScrollP2;
    public GameObject velocityScrollP2;

    void UIPlayer (string scroll) 
    {
        if (scroll == "damageScrollP1")
        {
            damageScrollP1.SetActive(true);
        }
        if (scroll == "disDamageScrollP1")
        {
            damageScrollP1.SetActive(false);
        }
        if (scroll == "velocityScrollP1")
        {
            velocityScrollP1.SetActive(true);
        }
        if (scroll == "disVelocityScrollP1")
        {
            velocityScrollP1.SetActive(false);
        }
        if (scroll == "damageScrollP2")
        {
            damageScrollP2.SetActive(true);
        }
        if (scroll == "disDamageScrollP2")
        {
            damageScrollP2.SetActive(false);
        }
        if (scroll == "velocityScrollP2")
        {
            velocityScrollP2.SetActive(true);
        }
        if (scroll == "disVelocityScrollP2")
        {
            velocityScrollP2.SetActive(false);
        }
    }
    private void OnEnable()
    {
        meleeplayer.onUIP1Change += UIPlayer;
        PlayerArcher.onUIP2Change += UIPlayer;
    }

    private void OnDisable()
    {
        meleeplayer.onUIP1Change -= UIPlayer;
        PlayerArcher.onUIP2Change -= UIPlayer;
    }
}
