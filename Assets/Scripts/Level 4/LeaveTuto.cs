using UnityEngine;
using System.Collections;

public class LeaveTuto : MonoBehaviour 
{
    public Transform Spawn;

    public GameObject[] GOToEnable;
    public GameObject[] GOToDisable;

    public MonoBehaviour[] MonoToEnable;
    public MonoBehaviour[] MonoToDisable;

    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject go in GOToEnable)
            go.SetActive(true);
        foreach (GameObject go in GOToDisable)
            go.SetActive(false);
        foreach (MonoBehaviour m in MonoToEnable)
            m.enabled = true;
        foreach (MonoBehaviour m in MonoToDisable)
            m.enabled = false;

        var st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();

        st.printText("Oh. We've been sent away.");
        st.printText("If y may give you a hint, I would suggest that you should avoid those vortexes.");

        col.transform.position = Spawn.position;
    }
}
