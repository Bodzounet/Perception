using UnityEngine;
using System.Collections;

public class SpawnWithLigthSwith : MonoBehaviour
{
    public LightManager.e_Lights spawningLight = LightManager.e_Lights.NONE;

    Renderer[] rds;
    Collider[] cols;
    ParticleSystem ps;

    LightManager _lm;

    void Awake()
    {
        _lm = GameObject.FindObjectOfType<LightManager>();

        rds = GetComponentsInChildren<Renderer>(true);
        cols = GetComponentsInChildren<Collider>(true);
        ps = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        OnLightChanged(_lm.CurrentLights);
    }

    void OnLightChanged(LightManager.e_Lights lights)
    {
        bool enabled = lights == spawningLight || lights == LightManager.e_Lights.BOTH;

        if (ps != null)
        {
            if (enabled)
            {
                ps.loop = true;
                ps.Play();
            }
            else
            {
                ps.loop = false;
            }
        }
        else
        {
            foreach (Renderer rd in rds)
            {
                rd.enabled = enabled;
            }
        }

        foreach (Collider col in cols)
        {
            col.enabled = enabled;
        }
    }

    void OnEnable()
    {
        _lm.LightHasChanged += OnLightChanged;
    }

    void OnDisable()
    {
        try
        {
            _lm.LightHasChanged += OnLightChanged;
        }
        catch
        {
            //osef, we're probably quitting
        }
    }
}
