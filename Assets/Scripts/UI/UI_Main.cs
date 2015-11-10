using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Main : MonoBehaviour 
{
    public GameObject[] visions; // Red, Green, Blue. In this order

    public void changeVision(VisionType vt)
    {
        for (int i = 0; i < visions.Length; i++)
        {
            if (i == (int)vt.CurrentVision)
                visions[i].SetActive(true);
            else
                visions[i].SetActive(false);
        }
    }
}
