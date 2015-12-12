using UnityEngine;
using System.Collections;

public class ScreenBehavior : MonoBehaviour
{
    public Material normal_view;
    public Material look;
    public float bpm = 120.0f;

    private bool isEnabled;
    private float elapsedTime;

    void Start()
    {
        isEnabled = false;
        elapsedTime = 0.0f;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 60.0f / bpm)
        {
            if (isEnabled)
            {
                gameObject.GetComponent<Renderer>().material = look;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = normal_view;
            }
            isEnabled = !isEnabled;
            elapsedTime = 0.0f;
        }
    }
}