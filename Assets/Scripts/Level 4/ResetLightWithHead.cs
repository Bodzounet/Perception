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
        if (ctrl.CheckShakingHead())
        {
            foreach (var tmp in GameObject.FindObjectsOfType<CheckVisible>())
                tmp.SendMessage("reset");
        }
    }
}
