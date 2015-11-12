using UnityEngine;
using System.Collections;

public class TestVision : OnVisionChangedBaseBehaviour
{
    Renderer rd;

    public VisionType.e_VisionType colorToSpawn;

    void Awake()
    {
        rd = this.GetComponent<Renderer>();
        rd.enabled = false;
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        if (vt.CurrentVision == colorToSpawn)
            rd.enabled = true;
        else
            rd.enabled = false;
    }
}
