using UnityEngine;
using System.Collections;

public abstract class OnVisionChangedBaseBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        GameObject.FindObjectOfType<SwitchVision>().visionTypeHasChanged += OnVisionHasChanged;
    }

    void OnDisable()
    {
        try
        {
            GameObject.FindObjectOfType<SwitchVision>().visionTypeHasChanged -= OnVisionHasChanged;
        }
        catch
        {
            // application is shuting down and that's why it failed, so we don't care. (99% sure...)
        }
    }

    public abstract void OnVisionHasChanged(VisionType vt);
}
