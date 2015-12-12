using UnityEngine;
using System.Collections;

public class OnVisionChangedPopDepop : OnVisionChangedBaseBehaviour
{
    [SerializeField]
    private VisionType.e_VisionType spawningVision;

    public VisionType.e_VisionType SpawningVision
    {
        get { return spawningVision; }
        set 
        { 
            spawningVision = value;
            OnVisionHasChanged(vm.CurrentVisionType);
        }
    }

    protected Collider[] _cols;
    protected Renderer[] _rds;

    Transform[] _childs;

    Color _baseColor;
    Color _invisible;

    bool previous = true;

    protected override void Awake()
    {
        base.Awake();

        _cols = GetComponentsInChildren<Collider>();
        _rds = GetComponentsInChildren<Renderer>();
        //_baseColor = _rds[0].material.color;
        //_invisible = new Color(_baseColor.r, _baseColor.g, _baseColor.b, 0);

        //_childs = GetComponentsInChildren<Transform>();

        //foreach (Transform child in _childs)
        //    child.gameObject.AddComponent<PopDepop>();

        //previous = (spawningVision == vm.CurrentVisionType.CurrentVision);
    }

    public override void OnVisionHasChanged(VisionType vt)
    {
        bool current = spawningVision == vt.CurrentVision;
        //if (current != previous)
        //{
        //    previous = current;
        //    foreach (Transform child in _childs)
        //        child.SendMessage(spawningVision == vt.CurrentVision ? "Pop" : "Depop");
        //}
        //else
        //{

        //}

        foreach (Collider c in _cols)
        {
            c.enabled = current;
        }

        foreach (Renderer r in _rds)
        {
            r.enabled = current;
        }

    }

    //IEnumerator PopDepop(bool endState)
    //{
    //    if (endState)
    //    {
    //        foreach (Collider c in _cols)
    //        {
    //            c.enabled = endState;
    //        }
    //    }

    //    float t = 0;
    //    bool tmpState = endState;

    //    while (t < timeAnim)
    //    {
    //        float delta = Random.Range(0, timeAnim / 5);
    //        t += delta;

    //        yield return new WaitForSeconds(delta);
    //        foreach (Renderer r in _rds)
    //        {
    //            r.enabled = tmpState;
    //        }
    //        tmpState = !tmpState;
    //    }

    //    if (!endState)
    //    {
    //        foreach (Collider c in _cols)
    //        {
    //            c.enabled = endState;
    //        }
    //    }

    //    foreach (Renderer r in _rds)
    //    {
    //        r.enabled = endState;
    //    }
    //}
}
