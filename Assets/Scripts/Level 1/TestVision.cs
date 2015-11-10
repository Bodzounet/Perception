using UnityEngine;
using System.Collections;

public class TestVision : SpawnWithSpecificVision
{
    Renderer rd;

    void Awake()
    {
        rd = this.GetComponent<Renderer>();
        rd.enabled = false;
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        if (vt.CurrentVision == VisionType.e_VisionType.RED)
            rd.enabled = true;
        else
            rd.enabled = false;
    }
}
