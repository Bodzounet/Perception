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
        animator = GetComponentInParent<Animator>();
        playerInActivationZone = false;
        notActivatedYet = true;
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Connard");
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
        if (vision.CurrentVisionType.CurrentVision == platformColor && playerInActivationZone && notActivatedYet && oculus.ShakingHeadChecker(0, 60.0f, 300.0f, 0.0f, 100.0f, 0.0f, 2))
        {
            Debug.Log("WEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            animator.Play("Movement");
            notActivatedYet = false;
        }
        else
        {
            //Debug.Log("Cond = " + (vision.CurrentVisionType.CurrentVision == platformColor) + " / " + (playerInActivationZone) + " / " + (notActivatedYet   ) + " / lol");
        }
    }
}
