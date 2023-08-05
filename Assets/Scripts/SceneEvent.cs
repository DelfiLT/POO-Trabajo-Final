using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEvent : MonoBehaviour
{
    public GameObject deathPanelP1;
    public GameObject revivePanelP1;
    public GameObject deathPanelP2;
    public GameObject revivePanelP2;

    void SelectedScene (string sceneName)
    {
        if(sceneName == "revivePanelP1")
        {
            revivePanelP1.SetActive(true);
        }

        if (sceneName == "disRevivePanelP1")
        {
            revivePanelP1.SetActive(false);
        }

        if (sceneName == "deathPanelP1")
        {
            deathPanelP1.SetActive(true);
        }

        if (sceneName == "revivePanelP2")
        {
            revivePanelP2.SetActive(true);
        }

        if (sceneName == "disRevivePanelP2")
        {
            revivePanelP2.SetActive(false);
        }

        if (sceneName == "deathPanelP2")
        {
            deathPanelP2.SetActive(true);
        }
    }

    private void OnEnable()
    {
        meleeplayer.onSceneChange += SelectedScene;
        PlayerArcher.onSceneChange += SelectedScene;
    }

    private void OnDisable()
    {
        meleeplayer.onSceneChange -= SelectedScene;
        PlayerArcher.onSceneChange -= SelectedScene;
    }
}
