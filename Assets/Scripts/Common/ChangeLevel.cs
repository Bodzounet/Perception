using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour 
{
    public string levelToLoadName;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Application.LoadLevel(levelToLoadName);
        }
    }
}
