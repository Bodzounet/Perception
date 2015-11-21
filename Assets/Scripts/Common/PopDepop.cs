using UnityEngine;
using System.Collections;

public class PopDepop : MonoBehaviour 
{
    Material _blackalpha;
    Material _original;
    Renderer _rd;
    Collider _col;

    void Awake()
    {
        _col = GetComponent<Collider>();
        _rd = GetComponent<Renderer>();
        _original = _rd.material;
        _blackalpha = Resources.Load<Material>("MAT_BlackAlpha");
    }

    public void Pop()
    {
        StartCoroutine("ChangeState", new ChangeStateData(true, new Color(0, 0, 0, 0), _original.color, _original));
    }

    public void Depop()
    {
        StartCoroutine("ChangeState", new ChangeStateData(false, Color.black, new Color(0, 0, 0, 0), _blackalpha));
    }

    public void PopInstant()
    {
        if (_rd)
            _rd.material = _original;
        if (_col)
            _col.enabled = true;

    }

    public void DepopInstant()
    {
        if (_rd)
        {
            _rd.material = _blackalpha;
            _rd.material.color = new Color(0, 0, 0, 0);
        }
        if (_col)
            _col.enabled = false;
    }

    IEnumerator ChangeState(ChangeStateData data)
    {
        for (int i = 0; i < 20; i++)
        {
            if (_rd != null)
                _rd.material.color = Color.Lerp(_rd.material.color, data.p1, 0.2f);
            yield return new WaitForSeconds(0.05f); // should wait in any case
        }

        if (_col != null)
            _col.enabled = data.state;

        _rd.material = data.mat;
        _rd.material.color = Color.black;

        for (int i = 0; i < 20; i++)
        {
            if (_rd != null)
            {
                _rd.material.color = Color.Lerp(_rd.material.color, data.p2, 0.2f);
                Debug.Log(_rd.material.color);
            }
            yield return new WaitForSeconds(1f);
        }
        if (_rd)
            _rd.material.color = data.p2;
    }

    struct ChangeStateData
    {
        public bool state;
        public Color p1;
        public Color p2;
        public Material mat;

        public ChangeStateData(bool s, Color c1, Color c2, Material m)
        {
            state = s;
            p1 = c1;
            p2 = c2;
            mat = m;
        }
    }
}
