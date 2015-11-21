using UnityEngine;
using System.Collections;

public class AdditionnalVisions : MonoBehaviour 
{
    VisionType.e_VisionType[] additionnalVisions = new VisionType.e_VisionType[2] {VisionType.e_VisionType.DEFAULT, VisionType.e_VisionType.DEFAULT};
   
    public enum e_add
    {
        NONE = 0,
        RED,
        BLUE,
        BOTH
    }

    public VisionType.e_VisionType Red
    {
        get
        {
            return additionnalVisions[0];
        }
    }

    public VisionType.e_VisionType Blue
    {
        get
        {
            return additionnalVisions[1];
        }
    }

    public void addVision(VisionType.e_VisionType v)
    {

    }

    public e_add CurrentAdditionalVisions
    {
        get
        {
            return (e_add)(additionnalVisions[0] == VisionType.e_VisionType.DEFAULT ? 0 : 1 + additionnalVisions[1] == VisionType.e_VisionType.DEFAULT ? 0 : 2);
        }
    }
}
