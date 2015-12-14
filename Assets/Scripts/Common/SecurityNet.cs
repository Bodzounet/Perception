using UnityEngine;
using System.Collections;

public class SecurityNet : MonoBehaviour 
{
    public delegate void Void_V_Void();
    public event Void_V_Void OnTriggering;

    public Transform SpawnPoint;

    bool _onlyOnce = false;

    SpawnText _st;

    void Awake()
    {
        _st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
    }

    void OnTriggerEnter(Collider col)
    {
        col.transform.position = SpawnPoint.position;
        if (OnTriggering != null)
            OnTriggering();

        if (!_onlyOnce)
        {
            _onlyOnce = true;
            _st.printText("WoW. What did just happend ?");
            _st.printText("I thought we were dead, but nop.");
            _st.printText("Good ! keep testing :)");
        }
    }
}
