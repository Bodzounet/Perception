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
        if (ctrl.ShakingHeadChecker(1, 45, 300, 0, 5, 0, 2))
        {
            foreach (var tmp in GameObject.FindObjectsOfType<CheckVisible>())
                tmp.SendMessage("reset");
        }
    }
}
