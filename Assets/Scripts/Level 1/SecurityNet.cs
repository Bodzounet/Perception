using UnityEngine;
using System.Collections;

public class SecurityNet : MonoBehaviour 
{
    public delegate void Void_V_Void();
    public event Void_V_Void OnTriggering;

    public Transform SpawnPoint;

    void OnTriggerEnter(Collider col)
    {
        col.transform.position = SpawnPoint.position;
        if (OnTriggering != null)
            OnTriggering();
    }
}
