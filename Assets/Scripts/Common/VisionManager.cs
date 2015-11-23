using UnityEngine;
using System.Collections;
using System.Linq;

public class VisionManager : MonoBehaviour
{
    public delegate void Void_D_VisionType(VisionType visionType);
    public event Void_D_VisionType visionTypeHasChanged;

    private VisionType _vt = new VisionType();

    public VisionType CurrentVisionType
    {
        get { return _vt; }
        set
        {
            _vt = value;
            
            if (visionTypeHasChanged != null)
            {
                visionTypeHasChanged(value);
            }

            Debug.Log("currentVision : " + _vt.CurrentVision.ToString());
        }
    }

    void Start()
    {
        if (visionTypeHasChanged != null)
        {
            visionTypeHasChanged(CurrentVisionType);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchVision+"))
        {
            CurrentVisionType++;
        }
        //if (Input.GetButtonDown("SwitchVision-"))
        //{
        //    CurrentVisionType--;
        //}
    }
}

public class VisionType
{
    public enum e_VisionType
    {
        RED = 0,
        GREEN,
        BLUE,
        DEFAULT
    };

    e_VisionType _currentVision = e_VisionType.DEFAULT;

    public e_VisionType CurrentVision
    {
        get { return _currentVision; }
        set { _currentVision = value; }
    }

    public VisionType()
    {
        _currentVision = e_VisionType.DEFAULT;
    }

    public static VisionType operator++(VisionType v)
    {
        int val = (int)v.CurrentVision;

        if (val == System.Enum.GetNames(typeof(e_VisionType)).Length - 1)
        {
            v.CurrentVision = (e_VisionType)0;
        }
        else
        {
            v.CurrentVision = (e_VisionType)(val + 1);
        }
        return v;
    }

    public static VisionType operator --(VisionType v)
    {
        int val = (int)v.CurrentVision;

        if (val == 0)
        {
            v.CurrentVision = (e_VisionType)(System.Enum.GetNames(typeof(e_VisionType)).Length - 1);
        }
        else
        {
            v.CurrentVision = (e_VisionType)(val - 1);
        }
        return v;
    }
}