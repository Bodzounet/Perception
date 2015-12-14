using UnityEngine;
using System.Collections;

public class ChangeLevelMechanics : MonoBehaviour 
{
    public CheckVisible changeMeca;
    public OnVisionChangedPopDepop[] depreatedScripts;
    public SpawnWithLigthSwith[] newScripts;
    public GameObject Ghost;

    void OnTriggerEnter(Collider col)
    {
        foreach (var v in depreatedScripts)
        {
            Destroy(v);
        }

        foreach (var v in newScripts)
        {
            v.enabled = true;
        }

        Ghost.SetActive(true);

        foreach (var v in Resources.FindObjectsOfTypeAll<SwitchEnvironmentColor>())
        {
            if (v.tag == "prefab")
                continue;
            v.gameObject.AddComponent<ModifyVisionColor>();
        }

        changeMeca.enabled = true;

        var st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
        st.printText("WoW ! What happened ?");
        st.printText("All colors are messed up :s");
        st.printText("I'm trying to repair it.");
        st.printText("Try to find a solution by yourself, it may take time before I fix the problem...");

        Destroy(this.gameObject);
    }
}
