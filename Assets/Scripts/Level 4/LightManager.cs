using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour 
{
    public delegate void Void_D_Light(e_Lights light);
    public event Void_D_Light LightHasChanged;

    public enum e_Lights
    {
        NONE,
        BLUE,
        RED,
        BOTH
    }

    private e_Lights currentLights;

    public e_Lights CurrentLights
    {
        get { return currentLights; }
        set 
        {
            currentLights = value;
            if (LightHasChanged != null)
                LightHasChanged(value);
        }
    }

    public void addLight(e_Lights light)
    {
        if (CurrentLights == e_Lights.NONE)
            CurrentLights = light;
        else if (CurrentLights == light || CurrentLights == e_Lights.BOTH)
            return;
        else
            CurrentLights = e_Lights.BOTH;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha0))
    //        CurrentLights = e_Lights.NONE;
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //        CurrentLights = e_Lights.BLUE;
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //        CurrentLights = e_Lights.RED;
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //        CurrentLights = e_Lights.BOTH;
    //}
}
