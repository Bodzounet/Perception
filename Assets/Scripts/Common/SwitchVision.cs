using UnityEngine;
using System.Collections;
using System.Linq;

public class SwitchVision : MonoBehaviour
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

            GameObject.FindObjectOfType<UI_Main>().changeVision(value);

            Debug.Log("currentVision : " + _vt.CurrentVision.ToString());
        }
    }

    void Awake()
    {

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
        if (Input.GetButtonDown("SwitchVision"))
        {
            CurrentVisionType++;
        }
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

    public static bool operator==(VisionType v1, VisionType v2)
    {
        if (v1 == null || v1 == null)
            return false;

        if (System.Object.ReferenceEquals(v1, v2))
            return true;

        return v1._currentVision == v2._currentVision;
    }

    public static bool operator !=(VisionType v1, VisionType v2)
    {
        return !(v1 == v2);
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
}