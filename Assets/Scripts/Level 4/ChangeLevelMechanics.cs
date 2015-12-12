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
            v.gameObject.AddComponent<ModifyVisionColor>();
        }

        changeMeca.enabled = true;

        Destroy(this.gameObject);
    }
}
