using UnityEngine;
using System.Collections;

public class AdditionnalVisions : MonoBehaviour 
{
    public delegate void Void_D_AdditionalVision(e_AdditionnalVision av);
    public event Void_D_AdditionalVision additionnialVisionsHasChanged;

    public enum e_AdditionnalVision
    {
        NONE = -1,
        RED = 0,
        BLUE = 2,
        BOTH
    }

    private e_AdditionnalVision _av = e_AdditionnalVision.NONE;

    public void addVision(e_AdditionnalVision av)
    {
        if (av != e_AdditionnalVision.BLUE && av != e_AdditionnalVision.RED)
            throw new System.Exception("must add red or blue, nothing else");

        if (av == e_AdditionnalVision.BOTH || _av == av)
            return;

        CurrentAdditionalVisions = (CurrentAdditionalVisions == e_AdditionnalVision.NONE) ? av : e_AdditionnalVision.BOTH;
    }

    public void resetVisions()
    {
        CurrentAdditionalVisions = e_AdditionnalVision.NONE;
    }

    public e_AdditionnalVision CurrentAdditionalVisions
    {
        get
        {
            return _av;
        }
        private set
        {
            _av = value;
            if (additionnialVisionsHasChanged != null)
                additionnialVisionsHasChanged(value);
        }
    }
}