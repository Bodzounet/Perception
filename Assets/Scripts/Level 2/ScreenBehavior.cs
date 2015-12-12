using UnityEngine;
using System.Collections;

public class ScreenBehavior : MonoBehaviour
{
    public Material normal_view;
    public Material look;
    public Material material_default;
    public float bpm = 120.0f;
    public VisionType.e_VisionType screenColor;

    VisionManager vision;
    Renderer gameObjRenderer;
    private bool isEnabled;
    private float elapsedTime;

    void Start()
    {
        vision = GameObject.Find("Player").GetComponent<VisionManager>();
        gameObjRenderer = gameObject.GetComponent<Renderer>();
        isEnabled = false;
        elapsedTime = 0.0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (vision.CurrentVisionType.CurrentVision == screenColor)
        {
            if (elapsedTime > 60.0f / bpm)
            {
                if (isEnabled) {
                    gameObjRenderer.material = look;
                } else {
                    gameObjRenderer.material = normal_view;
                }
            isEnabled = !isEnabled;
            elapsedTime = 0.0f;
            }
        }
        else
        {
            isEnabled = true;
            if (isEnabled)
            {
                gameObjRenderer.material = material_default;
                isEnabled = false;
            }
        }
        if (elapsedTime > 60.0f / bpm)
            elapsedTime = 0.0f;
    }
}