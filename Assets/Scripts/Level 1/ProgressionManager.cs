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
    public GameObject ToTheNextLevelPlatform;

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
        ToTheNextLevelPlatform.SetActive(true);
        Player.position = Spawn.position;
    }

    public void unlockDoor()
    {
        switch (--_locks)
        {
            case 2:
                GameObject.Find("Lock1").SendMessage("open");
                OnFirstLockActivation();
                break;
            case 1:
                GameObject.Find("Lock2").SendMessage("open");
                OnSecondLockActivation();
                break;
            case 0:
                GameObject.Find("Lock3").SendMessage("open");
                OnFinalActivation();
                Invoke("openDoor", 1.167f); // magic number... more seriously, the length of the anim.
                break;
            default:
                Debug.LogError("Should not happen");
                break;

        }
    }

    void openDoor()
    {
        GameObject.Find("Door").SendMessage("open");
    }

    void resetTriggersAfterFall()
    {
        foreach (GameObject go in Triggers)
            go.SetActive(true);
        mazeUp.GetComponent<OnVisionChangedPopDepop>().SpawningVision = VisionType.e_VisionType.DEFAULT;
    }
}
