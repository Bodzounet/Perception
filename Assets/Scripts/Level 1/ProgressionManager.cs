using UnityEngine;
using System.Collections;

public class ProgressionManager : MonoBehaviour
{
    public Transform Player;
    public Transform Spawn;

    int _locks = 3;

    public GameObject blockInTheMiddle;
    public GameObject maze;
    public GameObject mazeUp;
    public Material invisible;

    public GameObject unfair;

    public GameObject Occlusion;
    public GameObject[] Triggers;

    public Material CellShading;

    public GameObject Sas;

    SpawnText st;

    void Awake()
    {
        st = GameObject.Find("GUI_Text").GetComponent<SpawnText>();
    }

    public void OnFirstLockActivation()
    {
        blockInTheMiddle.SetActive(false);
        maze.GetComponent<Renderer>().material = invisible;
        Destroy(maze.GetComponent<SwitchEnvironmentColor>());
        mazeUp.SetActive(true);
        Player.position = Spawn.position;
        st.printText("Nice ! You've opened one lock");
        st.printText("But the maze vanished :/");
        st.printText("You should be able to make it respawn, right ?");
        st.printText("I'm pretty sure it's a matter of sight...");
    }

    public void OnSecondLockActivation()
    {
        Occlusion.SetActive(true);
        GameObject.FindObjectOfType<SecurityNet>().OnTriggering += resetTriggersAfterFall;
        resetTriggersAfterFall();
        Player.position = Spawn.position;
        unfair.SetActive(true);
        st.printText("Yeah ! Another one");
        st.printText("keep going");
    }

    public void OnFinalActivation()
    {
        Occlusion.SetActive(false);
        mazeUp.SetActive(false);
        maze.GetComponent<Renderer>().material = CellShading;
        maze.AddComponent<SwitchEnvironmentColor>();
        foreach (GameObject go in Triggers)
            go.SetActive(false);
        GameObject.FindObjectOfType<SecurityNet>().OnTriggering -= resetTriggersAfterFall;
        Player.position = Spawn.position;
        Sas.SendMessage("changeSasState", 1);
        st.printText("Well done, subject #357");
        st.printText("It was funny, wasn't it ? Let's do another one !");
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

    void resetTriggersAfterFall()
    {
        foreach (GameObject go in Triggers)
            go.SetActive(true);
        mazeUp.GetComponent<OnVisionChangedPopDepop>().SpawningVision = VisionType.e_VisionType.DEFAULT;
    }
}
