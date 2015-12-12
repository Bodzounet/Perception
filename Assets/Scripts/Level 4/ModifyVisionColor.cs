using UnityEngine;
using System.Collections;

/// <summary>
/// Dumb script to change color.
/// will work on disabled item too.
/// </summary>
public class ModifyVisionColor : MonoBehaviour 
{
    void Awake()
    {
        var switchEnvironmentColor = GetComponent<SwitchEnvironmentColor>();

        switchEnvironmentColor.Colors[0] = new Color(1, 1, 0.66f, switchEnvironmentColor.Mat.color.a);
        switchEnvironmentColor.Colors[1] = new Color(1, 0.66f, 1, switchEnvironmentColor.Mat.color.a);
        switchEnvironmentColor.Colors[2] = new Color(0.66f, 1, 1, switchEnvironmentColor.Mat.color.a);
        switchEnvironmentColor.OnVisionHasChanged(GameObject.FindObjectOfType<VisionManager>().CurrentVisionType);
        Destroy(this);
    }
}
