using UnityEngine;
using System.Collections;

public class MessageFirstTimeLightSwith : MonoBehaviour {

    LightManager _lm;

    void Start()
    {
        OnLightChanged(_lm.CurrentLights);
    }

    void OnLightChanged(LightManager.e_Lights lights)
    {
        var st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
        st.SendMessage("That's it. This strange light makes objects spawn, if they share the same color.");
        st.SendMessage("Good job.");

        Destroy(this.gameObject);
    }

    void OnEnable()
    {
        _lm.LightHasChanged += OnLightChanged;
    }

    void OnDisable()
    {
        try
        {
            _lm.LightHasChanged += OnLightChanged;
        }
        catch
        {
            //osef, we're probably quitting
        }
    }
}
