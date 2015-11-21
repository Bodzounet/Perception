using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchEnvironmentColor : OnVisionChangedBaseBehaviour
{
    public List<Color> colors = new List<Color> { new Color32(255, 165, 165, 255), new Color32(165, 255, 165, 255), new Color32(165, 165, 255, 255) }; // red, green, blue, in this order.

    private Material _mat;

    protected override void Awake()
    {
        base.Awake();

        _mat = GetComponent<Renderer>().material;
        colors.Add(new Color32(200, 200, 200, 255));
        //colors.Add(Color.white);
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        StopAllCoroutines();
        StartCoroutine("ChangeColor", colors[(int)vt.CurrentVision]);
    }

    IEnumerator ChangeColor(Color end)
    {
        while (_mat.color != end)
        {
            _mat.color = Color.Lerp(_mat.color, end, 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
