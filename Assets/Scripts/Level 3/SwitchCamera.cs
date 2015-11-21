using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchCamera : MonoBehaviour
{
    public Material cameraVoid;
    public List<Material> redVisionCameras;
    public List<Material> greenVisionCameras;
    public List<Material> blueVisionCameras;

    Transform tr;
    Transform playerTr;
    MeshRenderer meshRenderer;
    VisionManager vision;
    Dictionary<VisionType.e_VisionType, List<Material>> cameras;

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
    }
	
	void Update ()
    {
        int angleWithPlayer = (int)(tr.eulerAngles.y - playerTr.eulerAngles.y) % 360;
        VisionType.e_VisionType visionType = vision.CurrentVisionType.CurrentVision;

        //print(angleWithPlayer);
        if ((angleWithPlayer > 70 || angleWithPlayer < -240) && cameras.ContainsKey(visionType) && cameras[visionType][0] != null)
        {
            meshRenderer.material = cameras[visionType][0];
        }
        else if (angleWithPlayer < -70 && angleWithPlayer > -130 && cameras.ContainsKey(visionType) && cameras[visionType][1] != null)
        {
            meshRenderer.material = cameras[visionType][1];
        }
        else
        {
            meshRenderer.material = cameraVoid;
        }
	}
}
