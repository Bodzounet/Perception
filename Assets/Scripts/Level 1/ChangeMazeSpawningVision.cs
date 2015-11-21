using UnityEngine;
using System.Collections;

public class ChangeMazeSpawningVision : MonoBehaviour
{
    public VisionType.e_VisionType colorToSwapTo;

    OnVisionChangedPopDepop mazeScript;

    void Awake()
    {
        mazeScript = GameObject.Find("MazeUp").GetComponent<OnVisionChangedPopDepop>();
    }

    void OnTriggerEnter(Collider col)
    {
        mazeScript.SpawningVision = colorToSwapTo;
        gameObject.SetActive(false);
    }
}
