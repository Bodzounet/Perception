using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintTextOnTrigger : MonoBehaviour 
{
    SpawnText _st;

    public string[] messages;

    void Awake()
    {
        _st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            foreach (string s in messages)
                _st.printText(s);
            Destroy(this.gameObject);
        }
    }
}
