using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartEvent : MonoBehaviour
{
    public GameObject[] HeartsP1;
    public GameObject[] HeartsP2;
    
    void HeartsUI (string hearts)
    {
        if (hearts == "1HP1")
        {
            HeartsP1[2].SetActive(false);
        }
        if (hearts == "2HP1")
        {
            HeartsP1[1].SetActive(false);
        }
        if (hearts == "3HP1")
        {
            HeartsP1[0].SetActive(false);
        }
        if (hearts == "FULLHP1")
        {
            HeartsP1[0].SetActive(true);
            HeartsP1[1].SetActive(true);
            HeartsP1[2].SetActive(true);
        }

        if (hearts == "1HP2")
        {
            HeartsP2[2].SetActive(false);
        }
        if (hearts == "2HP2")
        {
            HeartsP2[1].SetActive(false);
        }
        if (hearts == "3HP2")
        {
            HeartsP2[0].SetActive(false);
        }
        if (hearts == "FULLHP2")
        {
            HeartsP2[0].SetActive(true);
            HeartsP2[1].SetActive(true);
            HeartsP2[2].SetActive(true);
        }
    }

    private void OnEnable()
    {
        meleeplayer.onHpChange += HeartsUI;
        PlayerArcher.onHpChange += HeartsUI;
    }

    private void OnDisable()
    {
        meleeplayer.onHpChange -= HeartsUI;
        PlayerArcher.onHpChange -= HeartsUI;
    }

}
