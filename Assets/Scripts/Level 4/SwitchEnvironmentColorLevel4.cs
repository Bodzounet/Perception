using UnityEngine;
using System.Collections;

public class SwitchEnvironmentColorLevel4 : SwitchEnvironmentColor
{
    AdditionnalVisions av;

    protected override void Awake()
    {
        base.Awake();

        av = GameObject.FindObjectOfType<AdditionnalVisions>();
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        //switch (vt.CurrentVision)
        //{
        //    case VisionType.e_VisionType.DEFAULT:
                
        //}

        StopAllCoroutines();
        StartCoroutine("ChangeColor", colors[(int)vt.CurrentVision]);
    }
}
