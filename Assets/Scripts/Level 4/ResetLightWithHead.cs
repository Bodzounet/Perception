using UnityEngine;
using System.Collections;

public class ResetLightWithHead : MonoBehaviour 
{
    OVRPlayerController ctrl;
    void Awake()
    {
        ctrl = GameObject.FindObjectOfType<OVRPlayerController>();
    }

    void Update()
    {
        if (ctrl.ShakingHeadChecker(1, 60, 300, 0, 10, 0, 1))
        {
            foreach (var tmp in GameObject.FindObjectsOfType<CheckVisible>())
                tmp.SendMessage("reset");
        }
    }
}
