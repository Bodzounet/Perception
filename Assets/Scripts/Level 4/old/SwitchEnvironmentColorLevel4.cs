using UnityEngine;
using System.Collections;

public class SwitchEnvironmentColorLevel4 : SwitchEnvironmentColor
{
    AdditionnalVisions av;

    protected override void Awake()
    {
        base.Awake();
        Colors.Add(new Color(1, 0.66f, 1f, Mat.color.a));
        Colors.Add(new Color(0.66f, 1f, 1f, Mat.color.a));
        Colors.Add(new Color(1, 1f, 0.66f, Mat.color.a));
        Colors.Add(new Color(1f, 1f, 1f, Mat.color.a));

        av = GameObject.FindObjectOfType<AdditionnalVisions>();
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        int idx = -1;

        switch (vt.CurrentVision)
        {
            case VisionType.e_VisionType.RED:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_AdditionnalVision.RED:
                    case AdditionnalVisions.e_AdditionnalVision.NONE:
                        idx = 0;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.BLUE:
                    case AdditionnalVisions.e_AdditionnalVision.BOTH:
                        idx = 4;
                        break;
                }
                break;
            case VisionType.e_VisionType.GREEN:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_AdditionnalVision.RED:
                        idx = 6;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.NONE:
                        idx = 1;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.BLUE:
                        idx = 5;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.BOTH:
                        idx = 7;
                        break;
                }
                break;
            case VisionType.e_VisionType.BLUE:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_AdditionnalVision.RED:
                    case AdditionnalVisions.e_AdditionnalVision.BOTH:
                        idx = 4;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.NONE:
                    case AdditionnalVisions.e_AdditionnalVision.BLUE:
                        idx = 2;
                        break;
                }
                break;
            case VisionType.e_VisionType.DEFAULT:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_AdditionnalVision.RED:
                        idx = 0;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.BOTH:
                        idx = 4;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.NONE:
                        idx = 3;
                        break;
                    case AdditionnalVisions.e_AdditionnalVision.BLUE:
                        idx = 2;
                        break;
                }
                break;
        }

        Debug.Log("idx : " + idx);
        StopAllCoroutines();
        StartCoroutine("ChangeColor", Colors[idx]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            av.addVision(AdditionnalVisions.e_AdditionnalVision.RED);
            OnVisionHasChanged(vm.CurrentVisionType);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            av.addVision(AdditionnalVisions.e_AdditionnalVision.BLUE);
            OnVisionHasChanged(vm.CurrentVisionType);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            av.resetVisions();
            OnVisionHasChanged(vm.CurrentVisionType);
        }
    }
}
