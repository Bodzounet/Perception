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

    public GameObject Occlusion;
    public GameObject[] Triggers;

    public Material CellShading;

    public GameObject Sas;

    public void OnFirstLockActivation()
    {
        blockInTheMiddle.SetActive(false);
        maze.GetComponent<Renderer>().material = invisible;
        Destroy(maze.GetComponent<SwitchEnvironmentColor>());
        mazeUp.SetActive(true);
        Player.position = Spawn.position;

        SpawnText.printText("Gratz ! You've just made all disappear. Keep going");
        SpawnText.printText("Maybe you should try another point of view...");
    }

    public void OnSecondLockActivation()
    {
        Occlusion.SetActive(true);
        GameObject.FindObjectOfType<SecurityNet>().OnTriggering += resetTriggersAfterFall;
        resetTriggersAfterFall();
        Player.position = Spawn.position;
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
