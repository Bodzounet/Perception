using UnityEngine;
using System.Collections;

public class ProgressionManager : MonoBehaviour
{
    public string Common = "---------------";

    public GameObject Player;
    public Transform Spawn;

    public string FirstSwitch = "---------------";

    public GameObject blockInTheMiddle;
    public GameObject maze;
    public Material invisible;

    void OnFirstLockActivation()
    {
        blockInTheMiddle.SetActive(false);
        maze.GetComponent<Renderer>().material = invisible;
    }
}
