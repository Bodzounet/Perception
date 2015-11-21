using UnityEngine;
using System.Collections;

public abstract class OnVisionChangedBaseBehaviour : MonoBehaviour
{
    protected VisionManager vm;

    virtual protected void Awake()
    {
        vm = GameObject.FindObjectOfType<VisionManager>();
    }

    void OnEnable()
    {
        vm.visionTypeHasChanged += OnVisionHasChanged;
        OnVisionHasChanged(vm.CurrentVisionType);
    }

    void OnDisable()
    {
        try
        {
            GameObject.FindObjectOfType<VisionManager>().visionTypeHasChanged -= OnVisionHasChanged;
        }
        catch
        {
            // application is shuting down and that's why it failed, so we don't care. (99% sure...)
        }
    }

    public abstract void OnVisionHasChanged(VisionType vt);
}
