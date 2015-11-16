using UnityEngine;
using System.Collections;

public class Switch_OnVisionChanged : OnVisionChangedBaseBehaviour
{
    public VisionType.e_VisionType spawningVision;

    Collider[] _cols;
    Renderer[] _rds;

    Color _baseColor;
    Color _invisible;

    void Awake()
    {
        _cols = GetComponentsInChildren<Collider>();
        _rds = GetComponentsInChildren<Renderer>();
        _baseColor = _rds[0].material.color;
        _invisible = new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0);
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        bool state = vt.CurrentVision == spawningVision;

        foreach (Collider c in _cols)
        {
            c.enabled = state;
        }
        foreach (Renderer r in _rds)
        {
            r.enabled = state;
            //StopAllCoroutines();
            //StartCoroutine(SoftPop_Depop.Soft(new SoftPop_Depop.softData(r, state == true ? _baseColor : _invisible)));
        }
    }
}
