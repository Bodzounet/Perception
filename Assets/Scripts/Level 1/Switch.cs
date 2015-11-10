using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
    bool _triggered = false;

    void OnTriggerStay(Collider col)
    {
        if (!_triggered && Input.GetButton("Action"))
        {
            _triggered = true;
            GameObject.FindObjectOfType<FinalLevelDoor>().unlockDoor();
        }
    }
}
