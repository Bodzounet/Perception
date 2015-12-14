﻿using UnityEngine;
using System.Collections;

public class RythmPlatformBehavior : MonoBehaviour
{
    public VisionType.e_VisionType platformColor;

    Animator animator;
    VisionManager vision;
    OVRPlayerController oculus;
    bool playerInActivationZone;
    bool notActivatedYet;
    int shakingAxis;
    int minAngle;
    int maxAngle;

    void Start ()
    {
        vision = GameObject.Find("Player").GetComponent<VisionManager>();
        oculus = GameObject.FindObjectOfType<OVRPlayerController>();
        animator = GetComponentInParent<Animator>();
        playerInActivationZone = false;
        notActivatedYet = true;
        if (platformColor == VisionType.e_VisionType.RED)
        {
            shakingAxis = 0;
            minAngle = -30;
            maxAngle = 15;
        }
        else if (platformColor == VisionType.e_VisionType.GREEN)
        {
            shakingAxis = 1;
            minAngle = -30;
            maxAngle = 15;
        }
        else if (platformColor == VisionType.e_VisionType.BLUE)
        {
            shakingAxis = 1;
            minAngle = -15;
            maxAngle = 30;
        }
        print(shakingAxis + " " + minAngle + " " + maxAngle);
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
        if (vision.CurrentVisionType.CurrentVision == platformColor && playerInActivationZone && notActivatedYet && oculus.ShakingHeadChecker(shakingAxis, minAngle, maxAngle, 0.3f, 0.5f, 0.0f, 2))
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
