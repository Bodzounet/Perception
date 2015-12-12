using UnityEngine;
using System.Collections;

public class RythmPlatformBehavior : MonoBehaviour
{
    public VisionType.e_VisionType platformColor;

    Animator animator;
    VisionManager vision;
    bool playerInActivationZone;
    bool notActivatedYet;

	void Start ()
    {
        vision = GameObject.Find("Player").GetComponent<VisionManager>();
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
        if (Input.GetButton("Action") && vision.CurrentVisionType.CurrentVision == platformColor && playerInActivationZone && notActivatedYet)
        {
            animator.Play("Movement");
            notActivatedYet = false;
        }
	}
}
