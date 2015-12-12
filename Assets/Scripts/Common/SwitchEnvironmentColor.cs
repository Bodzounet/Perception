using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchEnvironmentColor : OnVisionChangedBaseBehaviour
{
    private List<Color> _colors; // red, green, blue, white, in this order.

    public List<Color> Colors
    {
        get { return _colors; }
    }
    private Material _mat;

    public Material Mat
    {
        get { return _mat; }
    }

    protected override void Awake()
    {
        base.Awake();

        _mat = GetComponent<Renderer>().material;
        _colors = new List<Color>();
        _colors.Add(new Color(1, 0.66f, 0.66f, _mat.color.a));
        _colors.Add(new Color(0.66f, 1, 0.66f, _mat.color.a));
        _colors.Add(new Color(0.66f, 0.66f, 1, _mat.color.a));
        _colors.Add(new Color(0.9f, 0.9f, 0.9f, _mat.color.a));
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        StopAllCoroutines();
        StartCoroutine("ChangeColor", _colors[(int)vt.CurrentVision]);
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
