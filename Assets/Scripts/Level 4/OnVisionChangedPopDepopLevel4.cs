using UnityEngine;
using System.Collections;

public class OnVisionChangedPopDepopLevel4 : OnVisionChangedPopDepop
{
    AdditionnalVisions _av;

    protected override void Awake()
    {
        base.Awake();

        _av = GameObject.FindObjectOfType<AdditionnalVisions>();
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        bool current = vt.CurrentVision == SpawningVision || (int)_av.CurrentAdditionalVisions == (int)SpawningVision
            || (_av.CurrentAdditionalVisions == AdditionnalVisions.e_AdditionnalVision.BOTH && (SpawningVision == VisionType.e_VisionType.RED || SpawningVision == VisionType.e_VisionType.BLUE));

        foreach (Collider c in _cols)
        {
            c.enabled = current;
        }

        foreach (Renderer r in _rds)
        {
            r.enabled = current;
        }
    }

    public void OnAdditionnalColorHasChanged(AdditionnalVisions.e_AdditionnalVision av)
    {
        bool current = vm.CurrentVisionType.CurrentVision == SpawningVision || (int)av == (int)SpawningVision ||
            (av == AdditionnalVisions.e_AdditionnalVision.BOTH && (SpawningVision == VisionType.e_VisionType.RED || SpawningVision == VisionType.e_VisionType.BLUE) );

        foreach (Collider c in _cols)
        {
            c.enabled = current;
        }

        foreach (Renderer r in _rds)
        {
            r.enabled = current;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _av.additionnialVisionsHasChanged += OnAdditionnalColorHasChanged;
    }

    protected override void OnDisable()
    {
        try
        {
            GameObject.FindObjectOfType<VisionManager>().visionTypeHasChanged -= OnVisionHasChanged;
            _av.additionnialVisionsHasChanged -= OnAdditionnalColorHasChanged;
        }
        catch
        {
            // application is shuting down and that's why it failed, so we don't care. (99% sure...)
        }
    }
}
