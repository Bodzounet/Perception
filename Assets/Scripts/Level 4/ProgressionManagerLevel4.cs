using UnityEngine;
using System.Collections;

public class ProgressionManagerLevel4 : MonoBehaviour 
{
    int _locks = 3;

    public GameObject[] ItemToActivateOnFirstSwitch;
    public GameObject[] ItemToActivateOnSecondSwitch;
    public GameObject Sas;

    void OnFirstLockActivation()
    {
        foreach (GameObject go in ItemToActivateOnFirstSwitch)
            go.SetActive(true);
    }

    void OnSecondLockActivation()
    {
        foreach (GameObject go in ItemToActivateOnSecondSwitch)
            go.SetActive(true);
    }

    void OnFinalActivation()
    {
        Sas.SendMessage("ChangeSasState", 1);
    }

    public void unlockDoor()
    {
        switch (--_locks)
        {
            case 2:
                OnFirstLockActivation();
                break;
            case 1:
                OnSecondLockActivation();
                break;
            case 0:
                OnFinalActivation();
                break;
            default:
                Debug.LogError("Should not happen");
                break;
        }
    }
}
