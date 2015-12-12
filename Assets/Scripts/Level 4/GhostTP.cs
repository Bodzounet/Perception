using UnityEngine;
using System.Collections;

public class GhostTP : MonoBehaviour 
{
    public Transform Spawn;

    void OnTriggerEnter(Collider col)
    {
        col.transform.position = Spawn.position;
    }
}
