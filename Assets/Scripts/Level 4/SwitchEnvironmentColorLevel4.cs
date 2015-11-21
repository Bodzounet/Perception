using UnityEngine;
using System.Collections;

public class SwitchEnvironmentColorLevel4 : SwitchEnvironmentColor
{
    AdditionnalVisions av;

    protected override void Awake()
    {
        base.Awake();
        _colors.Add(new Color(1, 0.66f, 1f, _mat.color.a));
        _colors.Add(new Color(0.66f, 1f, 1f, _mat.color.a));
        _colors.Add(new Color(1, 1f, 0.66f, _mat.color.a));
        _colors.Add(new Color(1f, 1f, 1f, _mat.color.a));

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
                    case AdditionnalVisions.e_add.RED:
                    case AdditionnalVisions.e_add.NONE:
                        idx = 0;
                        break;
                    case AdditionnalVisions.e_add.BLUE:
                    case AdditionnalVisions.e_add.BOTH:
                        idx = 4;
                        break;
                }
                break;
            case VisionType.e_VisionType.GREEN:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_add.RED:
                        idx = 6;
                        break;
                    case AdditionnalVisions.e_add.NONE:
                        idx = 1;
                        break;
                    case AdditionnalVisions.e_add.BLUE:
                        idx = 5;
                        break;
                    case AdditionnalVisions.e_add.BOTH:
                        idx = 7;
                        break;
                }
                break;
            case VisionType.e_VisionType.BLUE:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_add.RED:
                    case AdditionnalVisions.e_add.BOTH:
                        idx = 4;
                        break;
                    case AdditionnalVisions.e_add.NONE:
                    case AdditionnalVisions.e_add.BLUE:
                        idx = 2;
                        break;
                }
                break;
            case VisionType.e_VisionType.DEFAULT:
                switch (av.CurrentAdditionalVisions)
                {
                    case AdditionnalVisions.e_add.RED:
                        idx = 0;
                        break;
                    case AdditionnalVisions.e_add.BOTH:
                        idx = 4;
                        break;
                    case AdditionnalVisions.e_add.NONE:
                        idx = 3;
                        break;
                    case AdditionnalVisions.e_add.BLUE:
                        idx = 2;
                        break;
                }
                break;
        }

        StopAllCoroutines();
        StartCoroutine("ChangeColor", _colors[idx]);
    }
}
