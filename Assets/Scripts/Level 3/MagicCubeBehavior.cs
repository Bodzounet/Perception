using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicCubeBehavior : MonoBehaviour
{
    public Material cameraVoid;
    public List<Material> redVisionCameras;
    public List<Material> greenVisionCameras;
    public List<Material> blueVisionCameras;

    public List<Transform> redVisionTPs;
    public List<Transform> greenVisionTPs;
    public List<Transform> blueVisionTPs;

    Transform tr;
    Transform playerTr;
    MeshRenderer meshRenderer;
    VisionManager vision;
    Dictionary<VisionType.e_VisionType, List<Material>> cameras;
    Dictionary<VisionType.e_VisionType, List<Transform>> TPs;

    void Start()
    {
        tr = this.GetComponent<Transform>();
        meshRenderer = this.GetComponent<MeshRenderer>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        vision = GameObject.Find("Player").GetComponent<VisionManager>();

        cameras = new Dictionary<VisionType.e_VisionType, List<Material>>();
        cameras[VisionType.e_VisionType.RED] = redVisionCameras;
        cameras[VisionType.e_VisionType.GREEN] = greenVisionCameras;
        cameras[VisionType.e_VisionType.BLUE] = blueVisionCameras;

        TPs = new Dictionary<VisionType.e_VisionType, List<Transform>>();
        TPs[VisionType.e_VisionType.RED] = redVisionTPs;
        TPs[VisionType.e_VisionType.GREEN] = greenVisionTPs;
        TPs[VisionType.e_VisionType.BLUE] = blueVisionTPs;

    }
	
	void Update ()
    {
        int angleWithPlayer = (int)(tr.eulerAngles.y - playerTr.eulerAngles.y) % 360;
        VisionType.e_VisionType visionType = vision.CurrentVisionType.CurrentVision;

        if (angleWithPlayer < 0)
        {
            angleWithPlayer += 360;
        }
        if (angleWithPlayer > 80 && angleWithPlayer < 110 && cameras.ContainsKey(visionType) && cameras[visionType][0] != null)
        {
            meshRenderer.material = cameras[visionType][0];
        }
        else if (angleWithPlayer > 250 && angleWithPlayer < 280 && cameras.ContainsKey(visionType) && cameras[visionType][1] != null)
        {
            meshRenderer.material = cameras[visionType][1];
        }
        else
        {
            meshRenderer.material = cameraVoid;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            int angleWithPlayer = (int)(tr.eulerAngles.y - playerTr.eulerAngles.y) % 360;
            VisionType.e_VisionType visionType = vision.CurrentVisionType.CurrentVision;

            if (angleWithPlayer < 0)
            {
                angleWithPlayer += 360;
            }
            if (angleWithPlayer > 80 && angleWithPlayer < 110 && cameras.ContainsKey(visionType) && cameras[visionType][0] != null)
            {
                playerTr.position = TPs[visionType][0].position;
            }
            else if (angleWithPlayer > 250 && angleWithPlayer < 280 && cameras.ContainsKey(visionType) && cameras[visionType][1] != null)
            {
                playerTr.position = TPs[visionType][1].position;
            }
        }
    }
}
