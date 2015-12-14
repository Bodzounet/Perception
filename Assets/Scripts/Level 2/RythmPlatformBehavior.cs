using UnityEngine;
using System.Collections;

public class RythmPlatformBehavior : MonoBehaviour
{
    public VisionType.e_VisionType platformColor;

    Animator animator;
    VisionManager vision;
    OVRPlayerController oculus;
    bool playerInActivationZone;
    bool notActivatedYet;

	void Start ()
    {
        vision = GameObject.Find("Player").GetComponent<VisionManager>();
        oculus = GameObject.FindObjectOfType<OVRPlayerController>();
        animator = GetComponent<Animator>();
        playerInActivationZone = false;
        notActivatedYet = true;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerInActivationZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            playerInActivationZone = false;
        }
    }

	void Update ()
    {
	    //This condition should be changed for the pattern detection
        if (oculus.ShakingHeadChecker(2, 30.0f, 60.0f, 60.0f / 120.0f, 60.0f / 130.0f, 0.0f, 2) && 
            vision.CurrentVisionType.CurrentVision == platformColor && playerInActivationZone && notActivatedYet)
        {
            Debug.Log("WEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            animator.Play("Movement");
            notActivatedYet = false;
        }
	}
}
