using UnityEngine;
using System.Collections;

public class UI_Credits : MonoBehaviour 
{
    Transform[] children;

    void Awake()
    {
        children = GetComponentsInChildren<Transform>();
    }

    void PrintNames()
    {
        foreach (Transform t in children)
        {
            if (t != transform)
            {
                t.SendMessage("Print");
            }
        }
    }
}
