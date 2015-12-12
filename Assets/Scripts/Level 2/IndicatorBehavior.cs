using UnityEngine;
using System.Collections;

public class IndicatorBehavior : MonoBehaviour
{
    public VisionType.e_VisionType indicatorColor;

    VisionManager vision;
    ParticleSystem particleSystem;
    
    void Start()
    {
        vision = GameObject.Find("Player").GetComponent<VisionManager>();
        particleSystem = GetComponent<ParticleSystem>();
	}
	
	void Update ()
    {
        if (vision.CurrentVisionType.CurrentVision == indicatorColor && particleSystem.isStopped)
        {
            particleSystem.Play();
        }
        else if (vision.CurrentVisionType.CurrentVision != indicatorColor && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
	}
}
