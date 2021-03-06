﻿using UnityEngine;
using System.Collections;

public class UI_Main : MonoBehaviour 
{
    public GameObject PanelCredit;
    public GameObject PanelChooseLevel;

    public void StartAventure()
    {
        Application.LoadLevel("Intro");
    }

    public void LoadSpecificLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void OpenClosePanelChooseLevel(bool state)
    {
        PanelChooseLevel.SetActive(state);
        PanelCredit.SetActive(false);
    }

    public void OpenClosePanelCredit(bool state)
    {
        PanelCredit.SetActive(state);
        if (state)
            PanelCredit.SendMessage("PrintNames");
        PanelChooseLevel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
