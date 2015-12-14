using UnityEngine;
using System.Collections;

public class ProgressionManagerLevel4 : MonoBehaviour 
{
    int _locks = 3;

    public GameObject[] ItemToActivateOnFirstSwitch;
    public GameObject[] ItemToActivateOnSecondSwitch;
    public GameObject Sas;

    SpawnText _st;

    void Awake()
    {
        _st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
    }

    void OnFirstLockActivation()
    {
        foreach (GameObject go in ItemToActivateOnFirstSwitch)
            go.SetActive(true);
        _st.printText("Nice work.");
        _st.printText("Look ! some new pillars has spawned.");
    }

    void OnSecondLockActivation()
    {
        foreach (GameObject go in ItemToActivateOnSecondSwitch)
            go.SetActive(true);
        _st.printText("You're doing well");
        _st.printText("Maybe those irradiations make you smarter ?");
        _st.printText("Do you feel clever, subject #357 ?");
    }

    void OnFinalActivation()
    {
        Sas.SendMessage("changeSasState", 1);
        _st.printText("Excellent ! If I had feelings, I would be so proud of you ! ");
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
