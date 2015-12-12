using UnityEngine;
using System.Collections;

public class Irradiation : MonoBehaviour
{
    public LightManager.e_Lights light;

    LightManager _lm;

    void Awake()
    {
        _lm = GameObject.FindObjectOfType<LightManager>();
    }

    void OnTriggerStay(Collider col)
    {
        _lm.addLight(light);
    }
}
