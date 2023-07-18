using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartEvent : MonoBehaviour
{
    public Sprite[] Hearts;
    public int heartCount;
    
    void HeartsUI ()
    {
        heartCount++;

        if (heartCount == 1)
        {
            Debug.Log("Sacar 1 corazon");
        }
        if (heartCount == 2)
        {
            Debug.Log("Sacar 2 corazon");
        }
        if (heartCount == 1)
        {
            Debug.Log("Sacar 3 corazon");
        }
        if (heartCount == 4)
        {
            heartCount = 0;
            Debug.Log("Poner corazones");
        }
    }

    private void OnEnable()
    {
        meleeplayer.heartEvent += HeartsUI;
    }

    private void OnDisable()
    {
        meleeplayer.heartEvent -= HeartsUI;
    }

}
