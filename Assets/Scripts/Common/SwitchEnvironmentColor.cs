using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchEnvironmentColor : OnVisionChangedBaseBehaviour
{
    protected List<Color> colors; // red, green, blue, white, in this order.

    private Material _mat;

    void Awake()
    {
        base.Awake();

        _mat = GetComponent<Renderer>().material;
        colors = new List<Color>();
        colors.Add(new Color(1, 0.66f, 0.66f, _mat.color.a));
        colors.Add(new Color(0.66f, 1, 0.66f, _mat.color.a));
        colors.Add(new Color(0.66f, 0.66f, 1, _mat.color.a));
        colors.Add(new Color(0.9f, 0.9f, 0.9f, _mat.color.a));
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
